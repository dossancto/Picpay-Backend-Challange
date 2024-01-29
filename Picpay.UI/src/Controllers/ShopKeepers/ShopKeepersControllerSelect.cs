using Microsoft.AspNetCore.Mvc;
using Picpay.Domain.Features.Mercant.Entities;

namespace Picpay.UI.Controllers.ShopKeepers;

public partial class ShopKeepersController
{
    /// <summary>
    /// List All ShopKeepers
    /// </summary>
    /// <remarks>List all ShopKeepers</remarks>
    /// <response code="200">The list of ShopKeepers</response>
    /// <response code="500">Fail while searching for ShopKeeper</response>
    [ProducesResponseType(typeof(List<ShopKeeper>), 200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<IActionResult> ListShopKeeper()
    {
        var result = await _selectShopKeeper.All();

        return Ok(result);
    }

    /// <summary>
    /// Get ShopKeeper by Id
    /// </summary>
    /// <remarks>Get a ShopKeeper by id</remarks>
    /// <response code="200">Find a ShopKeeper by id</response>
    /// <response code="500">Fail while searching for ShopKeeper</response>
    [ProducesResponseType(typeof(List<ShopKeeper>), 200)]
    [ProducesResponseType(500)]
    [HttpGet("{id}")]
    public async Task<IActionResult> ById(string id)
    {
        var result = await _selectShopKeeper.ById(id);

        return Ok(result);
    }
}
