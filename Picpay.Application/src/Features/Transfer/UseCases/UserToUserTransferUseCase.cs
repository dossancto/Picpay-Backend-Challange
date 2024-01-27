using System.ComponentModel.DataAnnotations;
using Picpay.Application.Features.Transfer.Data;

namespace Picpay.Application.Features.Transfer.UseCases;

/// <summary>
/// This class is responsible for transferring a balance from a user to another
/// </summary>
public class UserToUserTransferUseCase
{
    private readonly ITransferRepository _transferRepository;

    /// <summary>
    /// Injects dependencies
    /// </summary>
    public UserToUserTransferUseCase(ITransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    /// <summary>
    /// Executes a transfer from a user to another.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Execute(UserToUserTransfer dto)
    {
        // TODO: Make a GET request to pass only the id
        await _transferRepository.UserToUserTransfer(dto.From, dto.To, dto.Ammount);
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


