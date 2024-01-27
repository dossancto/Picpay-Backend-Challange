using Microsoft.AspNetCore.Mvc;
using Picpay.Application.Features.Users.UseCases;
using Picpay.Application.Features.Users.Entities;

namespace Picpay.UI.Controllers.Users;

public partial class UserController
{
    /// <summary>
    ///  Register User
    /// </summary>
    /// <remarks>Register a new User</remarks>
    /// <response code="201">Register a new User</response>
    /// <response code="500">Oops! Can't register a user now</response>
    [ProducesResponseType(typeof(User), 201)]
    [ProducesResponseType(500)]
    [HttpPost("register")]
    public async Task<ActionResult<User>> RegisterUser(RegisterUserDTO dto)
    {
        var user = await _register.Execute(dto);

        return Created("", user);
    }

    /// <summary>
    ///  Login User
    /// </summary>
    /// <remarks>Login as User</remarks>
    /// <response code="200">The login information</response>
    /// <response code="500">Oops! Can't register a user now</response>
    [ProducesResponseType(typeof(SafeUserResponse), 200)]
    [ProducesResponseType(500)]
    [HttpPost("login")]
    public async Task<ActionResult<SafeUserResponse>> LoginUser(LoginUserDTO dto)
    {
        var user = await _login.Execute(dto);

        var response = SafeUserResponse.From(user);

        return Ok(response);
    }
}

