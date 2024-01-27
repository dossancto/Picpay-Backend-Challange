using Microsoft.AspNetCore.Mvc;

using Picpay.Application.Features.Transfer.UseCases;

namespace Picpay.UI.Controllers.Transfer;

/// <summary>
/// Controller responsible for handling operations related to Transfer.
/// </summary>
[ApiController]
[Route("[controller]")]
public partial class TransferController : ControllerBase
{
    private readonly UserToUserTransferUseCase _userToUserTransfer;

    /// <summary>
    /// Dependency inject.
    /// </summary>
    public TransferController(UserToUserTransferUseCase userToUserTransfer)
    {
        _userToUserTransfer = userToUserTransfer;
    }
}

