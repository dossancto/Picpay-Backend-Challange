
using Picpay.Application.Features.Users.Data;
using Picpay.Application.Features.Users.Entities;

namespace Picpay.Application.Features.Users.UseCases;

/// <summary>
/// This class is responsible getting data from Users
/// </summary>
public class SelectUserUseCase
{
    private readonly IUserRepository _UserRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="SelectUserUseCase"/> class.
    /// </summary>
    /// <param name="UserRepository">The User repository.</param>
    public SelectUserUseCase(IUserRepository UserRepository)
    {
        _UserRepository = UserRepository;
    }

    /// <summary>
    /// Retrieves a note by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the note.</param>
    /// <returns>The task result contains the note if found, null otherwise.</returns>
    public Task<User?> ById(string id)
    => _UserRepository.FindById(id);

    /// <summary>
    /// Retrieves all notes.
    /// </summary>
    /// <returns>The task result contains a list of all notes.</returns>
    public Task<List<User>> All()
    => _UserRepository.All();
}

  