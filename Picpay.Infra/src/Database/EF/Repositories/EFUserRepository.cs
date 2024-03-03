using Picpay.Application.Features.Users.Data;
using Picpay.Domain.Features.Users.Entities;
using Picpay.Infra.Database.EF.Contexts;

using NanoidDotNet;
using Microsoft.EntityFrameworkCore;
using Picpay.Domain.Features.Transfer.Exceptions;

namespace Picpay.Infra.Database.EF.Repositories;

public class EFUserRepository
(ApplicationDbContext _context)
: IUserRepository
{
    public async Task<List<User>> All()
      => await _context.Users
                       .AsNoTrackingWithIdentityResolution()
                       .ToListAsync();

    public async Task Delete(string id)
    {
        var entity = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (entity is null)
            return;

        _context.Users.Remove(entity);

        await _context.SaveChangesAsync();
    }

    public Task<User?> FindByContact(string contact)
      => _context.Users
                       .AsNoTrackingWithIdentityResolution()
                       .Where(x =>
                           x.Id == contact ||
                           x.Email == contact ||
                           x.CPF == contact)
                       .SingleOrDefaultAsync();

    public async Task<User?> FindById(string id)
      => await _context.Users
                       .AsNoTrackingWithIdentityResolution()
                       .Where(x => x.Id == id)
                       .SingleOrDefaultAsync();

    public async Task<User> Save(User entity)
    {
        entity.Id = Nanoid.Generate();

        var createdUser = _context.Users.Add(entity);

        await _context.SaveChangesAsync();

        return createdUser.Entity;
    }

    public async Task<User> Update(User entity)
    {
        var updatedPlayer = _context.Users.Update(entity);

        await _context.SaveChangesAsync();

        return updatedPlayer.Entity;
    }

    public async Task AddAmmount(string id, decimal ammount)
    {
        var entity = await _context.Users
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
