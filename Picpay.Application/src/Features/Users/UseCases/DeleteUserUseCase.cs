using Picpay.Application.Features.Users.Data;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// This class encapsulates the use case of deleting a User.
/// </summary>
public class DeleteUserUseCase
(IUserRepository _UserRepository)
: IUseCase
{
    /// <summary>
    /// Deletes a User by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the User.</param>
    public Task Execute(string id)
    => _UserRepository.Delete(id);
}
