using Picpay.Application.Features.Users.Entities;
using Picpay.Application.Features.Users.Data;

using System.ComponentModel.DataAnnotations;
using Picpay.Adapters.Cryptographies;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// Register a new User
/// </summary>
public class RegisterUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptographys _cryptograph;

    public RegisterUserUseCase(IUserRepository userRepository, ICryptographys cryptograph)
    {
        _userRepository = userRepository;
        _cryptograph = cryptograph;
    }

    /// <summary>
    /// Executes the method
    /// </summary>
    public async Task<User> Execute(RegisterUserDTO dto)
    {
        var (hash, salt) = _cryptograph.HashPassword(dto.Password);

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            HashedPassword = hash,
            Salt = salt
        };

        return await _userRepository.Save(user);
    }
}

public record RegisterUserDTO
{
    /// <summary>
    /// The full user name .
    /// </summary>
    /// <example>All Might</example>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    /// The user email, must be a valid email address
    /// </summary>
    /// <example>allMight@ua.com</example>
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    /// <summary>
    /// The user Password to be hashed and stored. Must be secure
    /// </summary>
    /// <example> S#cur3Passw0rd </example>
    [Required]
    public required string Password { get; set; }
}
