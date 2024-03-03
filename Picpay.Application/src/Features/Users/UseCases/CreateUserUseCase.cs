using Picpay.Domain.Features.Users.Entities;
using Picpay.Application.Features.Users.Data;
using Picpay.Adapters.Cryptographies;
using Picpay.Application.Features.Accounts.UseCases;
using FluentValidation;
using Picpay.Application.Utils.Validation;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// This class is responsible for creating a User using a given repository.
/// </summary>
public class CreateUserUseCase
(IUserRepository _userRepository,
 ICryptographys _cryptographys,
 IValidator<CreteAccount> _createAccountValidator)
: IUseCase
{
    private const decimal INITIAL_CASH = 250m;

    /// <summary>
    /// Executes the creation of a User.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the User to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<User> Execute(CreateUser dto)
    {
        _createAccountValidator.Check(dto, "Fail while validating user creation");

        var (password, salt) = _cryptographys.HashPassword(dto.Password);

        var entity = dto.ToModel();

        entity.HashedPassword = password;
        entity.Salt = salt;

        entity.Balance = INITIAL_CASH;

        return _userRepository.Save(entity);
    }
}


/// <summary>
/// Represents a data object for creating a User
/// </summary>
public record CreateUser : CreteAccount
{
    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    public User ToModel()
    => new()
    {
        Fullname = Fullname,
        CPF = CPF,
        Email = Email,
        HashedPassword = string.Empty,
        Salt = string.Empty,
        Balance = 0m
    };
}

