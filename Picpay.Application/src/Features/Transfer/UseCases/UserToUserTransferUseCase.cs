using System.ComponentModel.DataAnnotations;

using Picpay.Domain.Features.Users.Entities;
using Picpay.Domain.Exceptions;
using Picpay.Domain.Features.Transfer.Exceptions;
using Picpay.Domain.Features.Transfer.Enums;

using Picpay.Adapters.Authorization;
using Picpay.Application.Features.Users.UseCases;
using MediatR;
using Picpay.Application.EventHandlers.Notifications.Transfer;
using Picpay.Domain.Utils;
using Picpay.Application.Features.Users.Data;

namespace Picpay.Application.Features.Transfer.UseCases;

/// <summary>
/// This class is responsible for transferring a balance from a user to another
/// </summary>
public class UserToUserTransferUseCase
(
 SelectUserUseCase _selectUser,
 IUserRepository _userRepository,
 IPaymentAuthorization _paymentAuthorization,
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
    public async Task Execute(UserToUserTransfer dto)
    {
        var work = async () =>
        {
            try
            {
                var (from, to) = await GetTransferingUsers(dto);

                await AssertCanTransfer(from, dto);

                var transation = new CreateTransactionEntity
                {
                    Sender = from.Id,
                    Receiver = to.Id,
                    Ammount = dto.Ammount,
                    EventType = TransactionEventType.Payment
                };

                await Run(transation);

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

    /// <summary>
    /// Effectively run the logic
    /// </summary>
    /// <param name="transation">The data transfer object containing the details of the User to be created.</param>
    public async Task Run(CreateTransactionEntity transation)
    {
        await _userRepository.AddAmmount(transation.Sender, -transation.Ammount);
        await _userRepository.AddAmmount(transation.Receiver, transation.Ammount);
    }

    /// <summary>
    /// Assets that the Account can transfer the money.
    /// </summary>
    private async Task AssertCanTransfer(User from, UserToUserTransfer dto)
    {
        if (from.Balance < dto.Ammount)
        {
            throw new TransferInsufientAmmountException(from.CPF, dto.Ammount, from.Balance);
        }

        var authorized = await _paymentAuthorization.IsAuthorized();

        if (!authorized)
        {
            throw new TransferException("Are not authorized to perform this transfer.");
        }
    }

    /// <summary>
    /// Get the 2 users for the transfer
    /// </summary>
    private async Task<(User from, User to)> GetTransferingUsers(UserToUserTransfer dto)
    {
        var notFoundMessage = (string x) => $"User with contact {x} not found";

        var from = await _selectUser.ByContact(dto.From)
              ?? throw new NotFoundException(notFoundMessage(dto.From));

        var to = await _selectUser.ByContact(dto.To)
              ?? throw new NotFoundException(notFoundMessage(dto.To));
        ;

        return (from, to);
    }
}

/// <summary>
/// Represents a data object for creating a User
/// </summary>
public record UserToUserTransfer
{
    /// <summary>
    /// The id, email or CPF of the payer.
    /// </summary>
    /// <example>test@test.com</example>
    [Required]
    public string From { get; set; } = default!;

    /// <summary>
    /// The id, email or CPF of the payee.
    /// </summary>
    /// <example>test@test.com</example>
    [Required]
    public string To { get; set; } = default!;

    /// <summary>
    /// The money to be transferred.
    /// </summary>
    /// <example>50.12</example>
    [Required]
    public decimal Ammount { get; set; }
}


