using Picpay.Domain.Exceptions;
using Picpay.Domain.Features.Mercant.Entities;
using Picpay.Domain.Features.Transfer.Exceptions;
using Picpay.Domain.Features.Users.Entities;
using Picpay.Domain.Features.Transfer.Enums;

using Picpay.Application.Features.ShopKeepers.UseCases;
using Picpay.Application.Features.Transfer.Data;
using Picpay.Application.Features.Users.UseCases;
using MediatR;
using Picpay.Application.EventHandlers.Notifications.Transfer;
using Picpay.Domain.Utils;
using Picpay.Application.Features.ShopKeepers.Data;
using Picpay.Application.Features.Users.Data;

namespace Picpay.Application.Features.Transfer.UseCases;

/// <summary>
/// This class is responsible for transferring a balance from a user to another
/// </summary>
public class UserToShopkeeperTransferUseCase
(IShopKeeperRepository _shopkeeperRepository,
 IUserRepository _userRepository,
 SelectUserUseCase _selectUser,
 SelectShopKeeperUseCase _selectShopkeeper,
 IMediator _mediator,
 IUnitOfWork _uow
 )
  : IUseCase
{
    /// <summary>
    /// Executes a transfer from a user to another.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Execute(UserToShopKeeperTransfer dto)
    {
        var work = async () =>
        {

            try
            {
                await Run(await Prepare(dto));

                await _mediator.Publish(new NewTransactionEvent
                {
                    OriginatorEmail = dto.From,
                    TargetEmail = dto.To,
                    Amount = dto.Ammount
                });
            }
            catch (Exception)
            {
                // TODO: Notify a Fail in Transfer.
                throw;
            }

        };

        await _uow.Sandbox(work);
    }

    private async Task<CreateTransactionEntity> Prepare(UserToShopKeeperTransfer dto)
    {
        var (from, to) = await GetTransferingUsers(dto);

        AssertCanTransfer(from, dto);

        return new CreateTransactionEntity
        {
            Sender = from.Id,
            Receiver = to.Id,
            Ammount = dto.Ammount,
            EventType = TransactionEventType.Payment
        };
    }

    /// <summary>
    /// Effectively run the logic
    /// </summary>
    private async Task Run(CreateTransactionEntity dto)
    {
        await _userRepository.AddAmmount(dto.Sender, -dto.Ammount);
        await _shopkeeperRepository.AddAmmount(dto.Receiver, dto.Ammount);
    }

    /// <summary>
    /// Assets that the Account can transfer the money.
    /// </summary>
    private void AssertCanTransfer(User from, UserToShopKeeperTransfer dto)
    {
        if (from.Balance < dto.Ammount)
        {
            throw new TransferInsufientAmmountException(from.CPF, dto.Ammount, from.Balance);
        }
    }

    /// <summary>
    /// Get the 2 users for the transfer
    /// </summary>
    private async Task<(User from, ShopKeeper to)> GetTransferingUsers(UserToShopKeeperTransfer dto)
    {
        var notFoundMessage = (string x) => $"User with contact {x} not found";

        var from = await _selectUser.ByContact(dto.From)
              ?? throw new NotFoundException(notFoundMessage(dto.From));

        var to = await _selectShopkeeper.ByContact(dto.To)
              ?? throw new NotFoundException(notFoundMessage(dto.To));
        ;

        return (from, to);
    }
}

/// <summary>
/// Represents a data object for creating a User
/// </summary>
public record UserToShopKeeperTransfer : TransferDTO { }
