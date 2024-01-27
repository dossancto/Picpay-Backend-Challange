using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Features.Users.Entities;

namespace Picpay.UI.Controllers.Users;

public partial class UsersController
{
    /// <summary>
    /// List All Users
    /// </summary>
    /// <remarks>List all Users</remarks>
    /// <response code="200">The list of Users</response>
    /// <response code="500">Fail while searching for User</response>
    [ProducesResponseType(typeof(List<User>), 200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<IActionResult> ListUser()
    {
        var result = await _selectUser.All();

        return Ok(result);
    }

    /// <summary>
    /// Get User by Id
    /// </summary>
    /// <remarks>Get a User by id</remarks>
    /// <response code="200">Find a User by id</response>
    /// <response code="500">Fail while searching for User</response>
    [ProducesResponseType(typeof(List<User>), 200)]
    [ProducesResponseType(500)]
    [HttpGet("{id}")]
    public async Task<IActionResult> ById(string id)
    {
        var result = await _selectUser.ById(id);

        return Ok(result);
    }
}
