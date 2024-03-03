using Picpay.Application.Features.ShopKeepers.Data;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.ShopKeepers.UseCases;

/// <summary>
/// This class encapsulates the use case of deleting a ShopKeeper.
/// </summary>
public class DeleteShopKeeperUseCase
(IShopKeeperRepository _ShopKeeperRepository) : IUseCase
{
    /// <summary>
    /// Deletes a ShopKeeper by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the ShopKeeper.</param>
    public Task Execute(string id)
    => _ShopKeeperRepository.Delete(id);
}
