using Picpay.Application.Features.Transfer.Data;
using Picpay.Domain.Features.Transfer.Entities;
using Picpay.Infra.Database.EF.Contexts;

using NanoidDotNet;
using Microsoft.EntityFrameworkCore;

namespace Picpay.Infra.Database.EF.Repositories;

public class EFTransactionEntityRepository(ApplicationDbContext _context) : ITransactionEntityRepository
{
    public async Task<List<TransactionEntity>> All()
      => await _context.Transations
                       .AsNoTrackingWithIdentityResolution()
                       .ToListAsync();

    public async Task Delete(string id)
    {
        var entity = await _context.Transations.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (entity is null)
            return;

        _context.Transations.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<TransactionEntity?> FindById(string id)
      => await _context.Transations
                       .AsNoTrackingWithIdentityResolution()
                       .Where(x => x.Id == id)
                       .SingleOrDefaultAsync();

    public async Task<TransactionEntity> Save(TransactionEntity entity)
    {
        entity.Id = Nanoid.Generate();

        var createdUser = _context.Transations.Add(entity);

        await _context.SaveChangesAsync();

        return createdUser.Entity;
    }

    public void SaveNoChanges(TransactionEntity entity)
    {
        entity.Id = Nanoid.Generate();

        _context.Transations.Add(entity);
    }

    public async Task<TransactionEntity> Update(TransactionEntity entity)
    {
        var updatedPlayer = _context.Transations.Update(entity);

        await _context.SaveChangesAsync();

        return updatedPlayer.Entity;
    }
}
