using Microsoft.AspNetCore.Mvc;

using Picpay.Application.Features.Transfer.UseCases;

namespace Picpay.UI.Controllers.Transfer;

/// <summary>
/// Controller responsible for handling operations related to Transfer.
/// </summary>
[ApiController]
[Route("[controller]")]
public partial class TransferController
(UserToUserTransferUseCase _userToUserTransfer,
 UserToShopkeeperTransferUseCase _userToShopKeeperTransfer)
: ControllerBase
;
