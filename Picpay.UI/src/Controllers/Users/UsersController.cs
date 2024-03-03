using Microsoft.AspNetCore.Mvc;

using Picpay.Application.Features.Users.UseCases;

namespace Picpay.UI.Controllers.Users;

/// <summary>
/// Controller responsible for handling operations related to Users.
/// </summary>
[ApiController]
[Route("[controller]")]
public partial class UsersController
(SelectUserUseCase _selectUser,
 DeleteUserUseCase _deleteUser,
 CreateUserUseCase _createUser)
: ControllerBase
;
