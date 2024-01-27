using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Features.Users.Entities;
using Picpay.Application.Features.Users.UseCases;

namespace Picpay.UI.Controllers.Users;

public partial class UsersController
{
    /// <summary>
    /// Craete User
    /// </summary>
    /// <remarks>Creates a new user</remarks>
    /// <response code="200">The created user</response>
    /// <response code="500">Fail while creataing user</response>
    [ProducesResponseType(typeof(User), 201)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUser request)
    {
        var result = await _createUser.Execute(request);

        return Created("", result);
    }
}

