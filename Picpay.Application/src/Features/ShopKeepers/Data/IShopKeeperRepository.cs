using Picpay.Domain.Features.Mercant.Entities;

namespace Picpay.Application.Features.ShopKeepers.Data;

/// <summary>
/// Defines operations for a ShopKeeper repository.
/// </summary>
public interface IShopKeeperRepository
{
    /// <summary>
    /// Save a new ShopKeeper
    /// </summary>
    /// <param name="entity">The entity to save</param>
    /// <returns>The created ShopKeeper</returns>
    Task<ShopKeeper> Save(ShopKeeper entity);

    /// <summary>
    /// Update a existint ShopKeeper
    /// </summary>
    /// <param name="entity">The entity to update</param>
    /// <returns>The updated ShopKeeper</returns>
    Task<ShopKeeper> Update(ShopKeeper entity);

    /// <summary>
    /// Search for a ShopKeeper using it Id
    /// </summary>
    /// <param name="id">The Entity Id</param>
    /// <returns>The search result or null, if not found</returns>
    Task<ShopKeeper?> FindById(string id);

    /// <summary>
    /// List all ShopKeeper
    /// </summary>
    /// <returns>A list of all ShopKeeper</returns>
    Task<List<ShopKeeper>> All();

    /// <summary>
    /// Delete a ShopKeeper
    /// </summary>
    Task Delete(string id);

    /// <summary>
    /// Search a user using Email, CPF or Id 
    /// </summary>
    /// <param name="contact">The contact to search, Email, CPF or Id</param>
    /// <returns>The search result or null, if not found</returns>
    Task<ShopKeeper?> ByContact(string contact);

    /// <summary>
    /// Change the ShopKeeper Balance
    /// </summary>
    Task AddAmmount(string id, decimal ammount);
}
