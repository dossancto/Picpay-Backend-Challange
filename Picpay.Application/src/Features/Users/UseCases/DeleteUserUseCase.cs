using Picpay.Application.Features.Users.Data;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// This class encapsulates the use case of deleting a User.
/// </summary>
public class DeleteUserUseCase : IUseCase
{
    private readonly IUserRepository _UserRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteUserUseCase"/> class.
    /// </summary>
    /// <param name="UserRepository">The User repository.</param>
    public DeleteUserUseCase(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;
    }

    /// <summary>
    /// Deletes a User by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the User.</param>
    public Task Execute(string id)
    => _UserRepository.Delete(id);
}
