using Picpay.Infra.Database.EF.Contexts;

using Picpay.Application.Features.Transfer.Data;

using Picpay.Domain.Features.Transfer.Exceptions;
using Picpay.Domain.Features.Transfer.Entities;

using Microsoft.EntityFrameworkCore;

namespace Picpay.Infra.Database.EF.Repositories;

public class EFTransferRepository
(
    ApplicationDbContext _context,
    ITransactionEntityRepository _transactionEntityRepository)
: ITransferRepository
{
    public async Task UserToShopkeeperTransfer(TransactionEntity entity)
    {
        using var transaction = _context.Database.BeginTransaction();

        var ammount = entity.Ammount;
        var from = entity.Sender;
        var to = entity.Receiver;

        try
        {
            var fromRows = _context.Database
              .ExecuteSql($@"UPDATE ""Users"" SET ""Balance"" = (""Balance"" - {ammount}) WHERE ""Id"" = {from}");

            if (fromRows == 0) throw new TransferException("Payer not found");

            var toRows = _context.Database
              .ExecuteSql($@"UPDATE ""ShopKeepers"" SET ""Balance"" = (""Balance"" + {ammount}) WHERE ""Id"" = {to}");

            if (toRows == 0) throw new TransferException("Payee not found");

            _transactionEntityRepository.SaveNoChanges(entity);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw new TransferException().WithDetails(e.Message);
        }
    }

    public async Task UserToUserTransfer(TransactionEntity entity)
    {
        using var transaction = _context.Database.BeginTransaction();

        var ammount = entity.Ammount;
        var from = entity.Sender;
        var to = entity.Receiver;

        try
        {
            var fromRows = _context.Database
              .ExecuteSql($@"UPDATE ""Users"" SET ""Balance"" = (""Balance"" - {ammount}) WHERE ""Id"" = {from}");

            if (fromRows == 0) throw new TransferException("Payer not found");

            var toRows = _context.Database
              .ExecuteSql($@"UPDATE ""Users"" SET ""Balance"" = (""Balance"" + {ammount}) WHERE ""Id"" = {to}");

            if (toRows == 0) throw new TransferException("Payee not found");

            _transactionEntityRepository.SaveNoChanges(entity);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw new TransferException().WithDetails(e.Message);
        }
    }
}
