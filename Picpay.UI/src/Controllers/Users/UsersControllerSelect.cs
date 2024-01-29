using Microsoft.AspNetCore.Mvc;
using Picpay.Domain.Features.Users.Entities;

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
    /// Get User by Contact
    /// </summary>
    /// <remarks>Search by a user using Email, CPF or Id.</remarks>
    /// <response code="200">The User as result.</response>
    /// <response code="500">Fail while searching for User</response>
    [ProducesResponseType(typeof(List<User>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpGet("{contact}")]
    public async Task<IActionResult> ById(string contact)
    {
        var result = await _selectUser.ByContact(contact);

        return Ok(result);
    }
}
