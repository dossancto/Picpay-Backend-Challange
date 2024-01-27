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

    public async Task UserToUserTransfer(string from, string to, decimal ammount)
    {
        using var transaction = _context.Database.BeginTransaction();

        try
        {
            _context.Database
              .ExecuteSql($@"UPDATE ""Users"" SET ""Balance"" = (""Balance"" - {ammount}) WHERE ""Id"" = {from}");

            _context.Database
              .ExecuteSql($@"UPDATE ""Users"" SET ""Balance"" = (""Balance"" + {ammount}) WHERE ""Id"" = {to}");


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
