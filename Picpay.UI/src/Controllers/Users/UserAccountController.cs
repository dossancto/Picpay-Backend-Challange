using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Features.Users.Entities;

namespace Picpay.UI.Controllers.Users;

public partial class UserController
{
    /// <summary>
    ///  Delete User
    /// </summary>
    /// <remarks>Delete a user using Id</remarks>
    /// <response code="200">User deleted</response>
    /// <response code="500">Oops! Can't delete this user now</response>
    [ProducesResponseType(typeof(User), 201)]
    [ProducesResponseType(500)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<User>> DeleteUser(string id)
    {
        await _delete.Execute(new() { Id = id });

        return Ok("User deleted successfully");
    }
}


