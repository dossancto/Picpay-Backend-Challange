
using Picpay.Application.Features.ShopKeepers.Data;
using Picpay.Application.Features.ShopKeepers.Entities;
using Picpay.Infra.Database.EF.Contexts;

using NanoidDotNet;
using Microsoft.EntityFrameworkCore;

namespace Picpay.Infra.Database.EF.Repositories;

public class EFShopKeeperRepository : IShopKeeperRepository
{
    private readonly ApplicationDbContext _context;

    public EFShopKeeperRepository(ApplicationDbContext context)
    => _context = context;

    public async Task<List<ShopKeeper>> All()
      => await _context.ShopKeepers
                       .AsNoTrackingWithIdentityResolution()
                       .ToListAsync();

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
}
