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
    private readonly UserToShopkeeperTransferUseCase _userToShopKeeperTransfer;

    /// <summary>
    /// Dependency inject.
    /// </summary>
    public TransferController(UserToUserTransferUseCase userToUserTransfer, UserToShopkeeperTransferUseCase userToShopKeeperTransfer)
    {
        _userToUserTransfer = userToUserTransfer;
        _userToShopKeeperTransfer = userToShopKeeperTransfer;
    }
}

