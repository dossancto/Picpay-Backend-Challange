using Picpay.Domain.Features.Users.Entities;

namespace Picpay.Application.Features.Users.Data;

/// <summary>
/// Defines operations for a User repository.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Save a new User
    /// </summary>
    /// <param name="entity">The entity to save</param>
    /// <returns>The created User</returns>
    Task<User> Save(User entity);

    /// <summary>
    /// Update a existint User
    /// </summary>
    /// <param name="entity">The entity to update</param>
    /// <returns>The updated User</returns>
    Task<User> Update(User entity);

    /// <summary>
    /// Search for a User using it Id
    /// </summary>
    /// <param name="id">The Entity Id</param>
    /// <returns>The search result or null, if not found</returns>
    Task<User?> FindById(string id);

    /// <summary>
    /// Search a user using Email, CPF or Id 
    /// </summary>
    /// <param name="contact">The contact to search, Email, CPF or Id</param>
    /// <returns>The search result or null, if not found</returns>
    Task<User?> FindByContact(string contact);

    /// <summary>
    /// List all User
    /// </summary>
    /// <returns>A list of all User</returns>
    Task<List<User>> All();

    /// <summary>
    /// Delete a User
    /// </summary>
    Task Delete(string id);
}
