using System.ComponentModel.DataAnnotations;
using Picpay.Application.Domain.Exceptions;
using Picpay.Application.Features.Transfer.Data;
using Picpay.Application.Features.Users.UseCases;

namespace Picpay.Application.Features.Transfer.UseCases;

/// <summary>
/// This class is responsible for transferring a balance from a user to another
/// </summary>
public class UserToUserTransferUseCase
{
    private readonly ITransferRepository _transferRepository;
    private readonly SelectUserUseCase _selectUser;

    /// <summary>
    /// Injects dependencies
    /// </summary>
    public UserToUserTransferUseCase(ITransferRepository transferRepository, SelectUserUseCase selectUser)
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
        var notFoundMessage = (string x) => $"User with contact {x} not found";

        var from = await _selectUser.ByContact(dto.From)
              ?? throw new NotFoundException(notFoundMessage(dto.From));

        var to = await _selectUser.ByContact(dto.To)
              ?? throw new NotFoundException(notFoundMessage(dto.To));
        ;

        await _transferRepository.UserToUserTransfer(from.Id, to.Id, dto.Ammount);
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


