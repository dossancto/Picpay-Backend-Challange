using Picpay.Domain.Utils;

using Picpay.Infra.Database.EF.Contexts;

using Microsoft.EntityFrameworkCore.Storage;

namespace Picpay.Infra.Database.EF.UnitOfWork;

public class EFUnitOfWork(ApplicationDbContext _context) : IUnitOfWork
{
    private IDbContextTransaction? Transaction { get; set; }

    public void Dispose()
    {
        if (Transaction is not null)
        {
            Transaction.Dispose();
        }
    }

    public async Task Begin()
    {
        Transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task Finish()
      => await DisposeAsync();

    public async Task Rollback()
    {
        if (Transaction is null) return;

        await Transaction.RollbackAsync();
    }

    public async Task Apply()
    {
        if (Transaction is null) return;

        await Transaction.CommitAsync();
    }

    public async ValueTask DisposeAsync()
    {
        if (Transaction is not null)
        {
            await Transaction.DisposeAsync();
        }
    }
}
