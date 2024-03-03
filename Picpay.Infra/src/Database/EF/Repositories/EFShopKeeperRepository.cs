using Picpay.Application.Features.ShopKeepers.Data;
using Picpay.Domain.Features.Mercant.Entities;
using Picpay.Infra.Database.EF.Contexts;

using NanoidDotNet;
using Microsoft.EntityFrameworkCore;
using Picpay.Domain.Features.Transfer.Exceptions;

namespace Picpay.Infra.Database.EF.Repositories;

public class EFShopKeeperRepository(ApplicationDbContext _context) : IShopKeeperRepository
{
    public async Task<List<ShopKeeper>> All()
      => await _context.ShopKeepers
                       .AsNoTrackingWithIdentityResolution()
                       .ToListAsync();

    public Task<ShopKeeper?> ByContact(string contact)
      => _context.ShopKeepers
                       .AsNoTrackingWithIdentityResolution()
                       .Where(x =>
                           x.Id == contact ||
                           x.Email == contact ||
                           x.CPF == contact)
                       .SingleOrDefaultAsync();

    public async Task Delete(string id)
    {
        var entity = await _context.ShopKeepers.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (entity is null)
            return;

        _context.ShopKeepers.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<ShopKeeper?> FindById(string id)
      => await _context.ShopKeepers
                       .AsNoTrackingWithIdentityResolution()
                       .Where(x => x.Id == id)
                       .SingleOrDefaultAsync();

    public async Task<ShopKeeper> Save(ShopKeeper entity)
    {
        entity.Id = Nanoid.Generate();

        var createdUser = _context.ShopKeepers.Add(entity);

        await _context.SaveChangesAsync();

        return createdUser.Entity;
    }

    public async Task<ShopKeeper> Update(ShopKeeper entity)
    {
        var updatedPlayer = _context.ShopKeepers.Update(entity);

        await _context.SaveChangesAsync();

        return updatedPlayer.Entity;
    }

    public async Task AddAmmount(string id, decimal ammount)
    {
        var entity = await _context.ShopKeepers
                  .Where(x => x.Id == id)
                  .ExecuteUpdateAsync(s =>
                      s.SetProperty(
                        p => p.Balance,
                        p => p.Balance + ammount
                        ));

        if (entity != 1)
        {
            throw new TransferException("Fail while updating balance");
        }

        await _context.SaveChangesAsync();
    }
}
