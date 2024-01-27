using Microsoft.AspNetCore.Mvc;

using Picpay.Application.Features.Transfer.UseCases;

namespace Picpay.UI.Controllers.Transfer;

public partial class TransferController
{
    /// <summary>
    /// User to User Transfer
    /// </summary>
    /// <remarks>Transfers money from a user to another</remarks>
    /// <response code="200">The money has been transferred</response>
    /// <response code="500">Fail while creataing user</response>
    [ProducesResponseType(201)]
    [ProducesResponseType(500)]
    [HttpPost("user-to-user")]
    public async Task<IActionResult> UserToUserTransfer(UserToUserTransfer request)
    {
        await _userToUserTransfer.Execute(request);

        return Ok("The ammount has been transferred");
    }

    /// <summary>
    /// User to ShopKeeper Transfer
    /// </summary>
    /// <remarks>Transfers money from a user to another</remarks>
    /// <response code="200">The money has been transferred</response>
    /// <response code="500">Fail while creataing user</response>
    [ProducesResponseType(201)]
    [ProducesResponseType(500)]
    [HttpPost("user-to-shopkeeper")]
    public async Task<IActionResult> UserToShopkeeperTransfer(UserToShopKeeperTransfer request)
    {
        await _userToShopKeeperTransfer.Execute(request);

        return Ok("The ammount has been transferred");
    }
}


