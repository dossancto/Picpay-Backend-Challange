using Picpay.Application.Features.Users.Entities;
using Picpay.Application.Features.Users.Data;

using System.ComponentModel.DataAnnotations;
using Picpay.Adapters.Cryptographies;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// Register a new User
/// </summary>
public class LoginUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptographys _cryptograph;

    /// <summary>
    /// Dependency invert the login usecase
    /// </summary>
    public LoginUserUseCase(IUserRepository userRepository, ICryptographys cryptograph)
    {
        _userRepository = userRepository;
        _cryptograph = cryptograph;
    }

    /// <summary>
    /// Executes the Login method
    /// </summary>
    public async Task<User> Execute(LoginUserDTO dto)
    {
        var user = await _userRepository.GetByEmail(dto.Email) ?? throw new Exception("User not found");
        var validPassword = _cryptograph.VerifyPassword(dto.Password, user.HashedPassword, user.Salt);

        if (!validPassword)
        {
            throw new Exception("Email or password incorrect");
        }

        return user;
    }
}

/// <summary>
/// DTO used to login a user
/// </summary>
public record LoginUserDTO
{
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

