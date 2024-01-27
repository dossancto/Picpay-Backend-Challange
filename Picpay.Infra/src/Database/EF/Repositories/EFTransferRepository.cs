using Picpay.Infra.Database.EF.Contexts;

using Microsoft.EntityFrameworkCore;
using Picpay.Application.Features.Transfer.Data;
using Picpay.Application.Features.Transfer.Exceptions;

namespace Picpay.Infra.Database.EF.Repositories;

public class EFTransferRepository : ITransferRepository
{
    private readonly ApplicationDbContext _context;

    public EFTransferRepository(ApplicationDbContext context)
    => _context = context;

    public async Task UserToShopkeeperTransfer(string from, string to, decimal ammount)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var fromRows = _context.Database
              .ExecuteSql($@"UPDATE ""Users"" SET ""Balance"" = (""Balance"" - {ammount}) WHERE ""Id"" = {from}");

            if (fromRows == 0) throw new TransferException("Payer not found");

            var toRows = _context.Database
              .ExecuteSql($@"UPDATE ""ShopKeepers"" SET ""Balance"" = (""Balance"" + {ammount}) WHERE ""Id"" = {to}");

            if (toRows == 0) throw new TransferException("Payee not found");

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync();
            throw new TransferException().WithDetails(e.Message);
        }
    }

    public async Task UserToUserTransfer(string from, string to, decimal ammount)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            var fromRows = _context.Database
              .ExecuteSql($@"UPDATE ""Users"" SET ""Balance"" = (""Balance"" - {ammount}) WHERE ""Id"" = {from}");

            if (fromRows == 0) throw new TransferException("Payer not found");

            var toRows = _context.Database
              .ExecuteSql($@"UPDATE ""Users"" SET ""Balance"" = (""Balance"" + {ammount}) WHERE ""Id"" = {to}");

            if (toRows == 0) throw new TransferException("Payee not found");

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
