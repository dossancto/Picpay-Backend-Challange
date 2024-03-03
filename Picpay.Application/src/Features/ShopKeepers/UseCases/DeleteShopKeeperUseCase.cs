using Picpay.Application.Features.ShopKeepers.Data;
using Picpay.Domain.Utils;

namespace Picpay.Application.Features.ShopKeepers.UseCases;

/// <summary>
/// This class encapsulates the use case of deleting a ShopKeeper.
/// </summary>
public class DeleteShopKeeperUseCase : IUseCase
{
    private readonly IShopKeeperRepository _ShopKeeperRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteShopKeeperUseCase"/> class.
    /// </summary>
    /// <param name="ShopKeeperRepository">The ShopKeeper repository.</param>
    public DeleteShopKeeperUseCase(IShopKeeperRepository ShopKeeperRepository)
    {
        _ShopKeeperRepository = ShopKeeperRepository;
    }

    /// <summary>
    /// Deletes a ShopKeeper by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the ShopKeeper.</param>
    public Task Execute(string id)
    => _ShopKeeperRepository.Delete(id);
}
