using Picpay.Application.Features.Users.Data;

using System.ComponentModel.DataAnnotations;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// Delete a user
/// </summary>
public class DeleteUserUseCase
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Dependency invert the Delete usecase
    /// </summary>
    public DeleteUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Executes the Delete Use Case
    /// </summary>
    public async Task Execute(DeleteUserDTO dto)
    {
        Console.WriteLine($"User id => {dto.Id}");
        await _userRepository.DeleteById(dto.Id);
    }
}

/// <summary>
/// DTO used to delete a user
/// </summary>
public record DeleteUserDTO
{
    /// <summary>
    /// The user Id to be deleted.
    /// </summary>
    /// <example>5Zsqvr9gx1fhIPAyHGYrD</example>
    [Required]
    public required string Id { get; set; }
}


