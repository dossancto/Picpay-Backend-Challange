using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Features.ShopKeepers.Entities;
using Picpay.Application.Features.ShopKeepers.UseCases;

namespace Picpay.UI.Controllers.ShopKeepers;

public partial class ShopKeepersController
{
    /// <summary>
    /// Craete ShopKeeper
    /// </summary>
    /// <remarks>Creates a new ShopKeeper</remarks>
    /// <response code="200">The created ShopKeeper</response>
    /// <response code="500">Fail while creataing ShopKeeper</response>
    [ProducesResponseType(typeof(ShopKeeper), 201)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<IActionResult> CreateShopKeeper(CreateShopKeeper request)
    {
        var result = await _createShopKeeper.Execute(request);

        return Created("", result);
    }
}

