using System.ComponentModel.DataAnnotations;

using Picpay.Domain.Features.Users.Entities;
using Picpay.Domain.Exceptions;
using Picpay.Domain.Features.Transfer.Exceptions;
using Picpay.Domain.Features.Transfer.Enums;

using Microsoft.Extensions.Logging;
using Picpay.Adapters.Authorization;
using Picpay.Adapters.Notification;
using Picpay.Application.Features.Transfer.Data;
using Picpay.Application.Features.Users.UseCases;
using MediatR;
using Picpay.Application.EventHandlers.Notifications.Transfer;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.Transfer.UseCases;

/// <summary>
/// This class is responsible for transferring a balance from a user to another
/// </summary>
public class UserToUserTransferUseCase : IUseCase
{
    private readonly ITransferRepository _transferRepository;
    private readonly SelectUserUseCase _selectUser;
    private readonly IPaymentAuthorization _paymentAuthorization;
    private readonly INofificationSender _notificationSender;
    private readonly ILogger<UserToUserTransferUseCase> logger;
    private readonly IMediator _mediator;

    /// <summary>
    /// Injects dependencies
    /// </summary>
    public UserToUserTransferUseCase(ITransferRepository transferRepository, SelectUserUseCase selectUser, IPaymentAuthorization paymentAuthorization, INofificationSender notificationSender, ILogger<UserToUserTransferUseCase> logger, IMediator mediator)
    {
        _transferRepository = transferRepository;
        _selectUser = selectUser;
        _paymentAuthorization = paymentAuthorization;
        _notificationSender = notificationSender;
        this.logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Executes a transfer from a user to another.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Execute(UserToUserTransfer dto)
    {
        try
        {
            await Run(dto);

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
    }

    /// <summary>
    /// Effectively run the logic
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be created.</param>
    public async Task Run(UserToUserTransfer dto)
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

        await _transferRepository.UserToUserTransfer(transation.ToModel());
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


