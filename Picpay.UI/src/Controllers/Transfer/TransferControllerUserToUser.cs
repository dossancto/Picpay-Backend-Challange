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
    [HttpPost]
    public async Task<IActionResult> CreateUser(UserToUserTransfer request)
    {
        await _userToUserTransfer.Execute(request);

        return Ok("The ammount has been transferred");
    }
}


