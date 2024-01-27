using Microsoft.AspNetCore.Mvc;

using Picpay.Application.Features.Users.UseCases;

namespace Picpay.UI.Controllers.Users;

/// <summary>
/// Controller responsible for handling operations related to Users.
/// </summary>
[ApiController]
[Route("[controller]")]
public partial class UsersController : ControllerBase
{
    private readonly CreateUserUseCase _createUser;
    private readonly DeleteUserUseCase _deleteUser;
    private readonly SelectUserUseCase _selectUser;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersController"/> class.
    /// </summary>
    public UsersController(SelectUserUseCase selectUser, DeleteUserUseCase deleteUser, CreateUserUseCase createUser)
    {
        _selectUser = selectUser;
        _deleteUser = deleteUser;
        _createUser = createUser;
    }
}
