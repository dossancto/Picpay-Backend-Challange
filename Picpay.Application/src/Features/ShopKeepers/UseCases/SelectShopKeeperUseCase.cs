using Picpay.Application.Features.ShopKeepers.Data;
using Picpay.Domain.Features.Mercant.Entities;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.ShopKeepers.UseCases;

/// <summary>
/// This class is responsible getting data from ShopKeepers
/// </summary>
public class SelectShopKeeperUseCase
(IShopKeeperRepository _shopKeeperRepository)
: IUseCase
{
    /// <summary>
    /// Retrieves a note by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the note.</param>
    /// <returns>The task result contains the note if found, null otherwise.</returns>
    public Task<ShopKeeper?> ById(string id)
    => _shopKeeperRepository.FindById(id);

    /// <summary>
    /// Retrieves all notes.
    /// </summary>
    /// <returns>The task result contains a list of all notes.</returns>
    public Task<List<ShopKeeper>> All()
    => _shopKeeperRepository.All();

    /// <summary>
    /// Find a Shopkeeper using Email, CPF or Id;
    /// </summary>
    /// <param name="contact">The contact id, Email, CPF or Id</param>
    public Task<ShopKeeper?> ByContact(string contact)
    => _shopKeeperRepository.ByContact(contact);
}


