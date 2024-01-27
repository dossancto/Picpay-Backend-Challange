using Microsoft.AspNetCore.Mvc;

using Picpay.Application.Features.ShopKeepers.UseCases;

namespace Picpay.UI.Controllers.ShopKeepers;

/// <summary>
/// Controller responsible for handling operations related to ShopKeepers.
/// </summary>
[ApiController]
[Route("[controller]")]
public partial class ShopKeepersController : ControllerBase
{
    private readonly CreateShopKeeperUseCase _createShopKeeper;
    private readonly DeleteShopKeeperUseCase _deleteShopKeeper;
    private readonly SelectShopKeeperUseCase _selectShopKeeper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShopKeepersController"/> class.
    /// </summary>
    public ShopKeepersController(SelectShopKeeperUseCase selectShopKeeper, DeleteShopKeeperUseCase deleteShopKeeper, CreateShopKeeperUseCase createShopKeeper)
    {
        _selectShopKeeper = selectShopKeeper;
        _deleteShopKeeper = deleteShopKeeper;
        _createShopKeeper = createShopKeeper;
    }
}
