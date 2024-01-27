using System.ComponentModel.DataAnnotations;
using Picpay.Application.Features.Users.Data;
using Picpay.Application.Features.Users.Entities;
using Picpay.Adapters.Cryptographies;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// This class is responsible for creating a User using a given repository.
/// </summary>
public class CreateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly ICryptographys _cryptographys;

    private const decimal INITIAL_CASH = 250m;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserUseCase"/> class.
    /// </summary>
    /// <param name="UserRepository">The User repository.</param>
    /// <param name="cryptographys">The cryptographys algorithm.</param>
    public CreateUserUseCase(IUserRepository UserRepository, ICryptographys cryptographys)
    {
        _userRepository = UserRepository;
        _cryptographys = cryptographys;
    }

    /// <summary>
    /// Executes the creation of a User.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<User> Execute(CreateUser dto)
    {
        var (password, salt) = _cryptographys.HashPassword(dto.Password);

        var entity = dto.ToModel(salt);

        entity.HashedPassword = password;
        entity.Balance = INITIAL_CASH;

        return _userRepository.Save(entity);
    }
}


/// <summary>
/// Represents a data object for creating a User
/// </summary>
public record CreateUser
{
    /// <summary>
    /// Fullname
    /// </summary>
    /// <example>Picpay Tester</example>
    [Required]
    public string Fullname { get; set; } = default!;

    /// <summary>
    /// CPF
    /// </summary>
    /// <example>00000000000</example>
    [Required]
    [Length(minimumLength: 11, maximumLength: 11)]
    public string CPF { get; set; } = default!;

    /// <summary>
    /// Email
    /// </summary>
    /// <example>test@test.com</example>
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Password
    /// </summary>
    /// <example>A_Secure_Password</example>
    [Required]
    [MinLength(8)]
    public string Password { get; set; } = default!;

    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    /// <returns>The note model.</returns>
    public User ToModel(string salt)
    => new()
    {
        Fullname = Fullname,
        CPF = CPF,
        Email = Email,
        HashedPassword = string.Empty,
        Salt = salt,
        Balance = 0m
    };
}

