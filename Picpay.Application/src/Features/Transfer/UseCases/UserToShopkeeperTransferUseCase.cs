using Microsoft.Extensions.Logging;
using Picpay.Adapters.Notification;
using Picpay.Application.Domain.Exceptions;
using Picpay.Application.Features.ShopKeepers.Entities;
using Picpay.Application.Features.ShopKeepers.UseCases;
using Picpay.Application.Features.Transfer.Data;
using Picpay.Application.Features.Transfer.Exceptions;
using Picpay.Application.Features.Users.Entities;
using Picpay.Application.Features.Users.UseCases;

namespace Picpay.Application.Features.Transfer.UseCases;

/// <summary>
/// This class is responsible for transferring a balance from a user to another
/// </summary>
public class UserToShopkeeperTransferUseCase
{
    private readonly ITransferRepository _transferRepository;
    private readonly SelectUserUseCase _selectUser;
    private readonly SelectShopKeeperUseCase _selectShopkeeper;
    private readonly INofificationSender _notificationSender;
    private readonly ILogger<UserToShopkeeperTransferUseCase> logger;

    /// <summary>
    /// Injects dependencies
    /// </summary>
    public UserToShopkeeperTransferUseCase(ITransferRepository transferRepository, SelectUserUseCase selectUser, SelectShopKeeperUseCase selectShopkeeper, INofificationSender notificationSender, ILogger<UserToShopkeeperTransferUseCase> logger)
    {
        _transferRepository = transferRepository;
        _selectUser = selectUser;
        _selectShopkeeper = selectShopkeeper;
        _notificationSender = notificationSender;
        this.logger = logger;
    }

    /// <summary>
    /// Executes a transfer from a user to another.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Execute(UserToShopKeeperTransfer dto)
    {
        var (from, to) = await GetTransferingUsers(dto);

        AssertCanTransfer(from, dto);

        await _transferRepository.UserToShopkeeperTransfer(from.Id, to.Id, dto.Ammount);

        await Notify(dto);
    }

    private async Task Notify(UserToShopKeeperTransfer dto)
    {
        try
        {
            await _notificationSender.NotifyTransaction(new NotifyEmailTransaction(dto.From, dto.To, dto.Ammount));
        }
        catch (Exception e)
        {
            logger.LogError(e.ToString());
        }

        try
        {
            await _notificationSender.NotifyTransaction(new NotifySmsTransaction(dto.From, dto.To, dto.Ammount));
        }
        catch (Exception e)
        {
            logger.LogError(e.ToString());
        }
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
