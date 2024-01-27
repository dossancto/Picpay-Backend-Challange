using System.ComponentModel.DataAnnotations;
using Picpay.Application.Domain.Exceptions;
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

    /// <summary>
    /// Injects dependencies
    /// </summary>
    public UserToShopkeeperTransferUseCase(ITransferRepository transferRepository, SelectUserUseCase selectUser)
    {
        _transferRepository = transferRepository;
        _selectUser = selectUser;
    }

    /// <summary>
    /// Executes a transfer from a user to another.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Execute(UserToUserTransfer dto)
    {
        var (from, to) = await GetTransferingUsers(dto);

        AssertCanTransfer(from, dto);

        await _transferRepository.UserToUserTransfer(from.Id, to.Id, dto.Ammount);
    }

    /// <summary>
    /// Assets that the Account can transfer the money.
    /// </summary>
    private void AssertCanTransfer(User from, UserToUserTransfer dto)
    {
        if (from.Balance < dto.Ammount)
        {
            throw new TransferInsufientAmmountException(from.CPF, dto.Ammount, from.Balance);
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
public record UserToShopKeeperTransfer
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



