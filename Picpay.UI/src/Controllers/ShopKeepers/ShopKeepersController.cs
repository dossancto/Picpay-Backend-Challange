using Microsoft.AspNetCore.Mvc;

using Picpay.Application.Features.ShopKeepers.UseCases;

namespace Picpay.UI.Controllers.ShopKeepers;

/// <summary>
/// Controller responsible for handling operations related to ShopKeepers.
/// </summary>
[ApiController]
[Route("[controller]")]
public partial class ShopKeepersController
(SelectShopKeeperUseCase _selectShopKeeper,
 DeleteShopKeeperUseCase _deleteShopKeeper,
 CreateShopKeeperUseCase _createShopKeeper)
: ControllerBase
;
