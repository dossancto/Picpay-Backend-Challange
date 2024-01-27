using Picpay.Application.Features.Users.Data;
using NanoidDotNet;
using Picpay.Application.Features.Users.Entities;
using Picpay.Infra.Database.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Picpay.Infra.Database.EF.Repositories;

public class EFUserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public EFUserRepository(ApplicationDbContext context)
    => _context = context;

    public async Task<User> Update(User player)
    {
        var updatedPlayer = _context.Users.Update(player);

        await _context.SaveChangesAsync();

        return updatedPlayer.Entity;
    }

    public async Task<User> Save(User user)
    {
        user.Id = Nanoid.Generate();

        var createdUser = _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return createdUser.Entity;
    }

    public async Task<User?> GetByEmail(string email)
      => await _context.Users
                       .AsNoTrackingWithIdentityResolution()
                       .Where(x => x.Email == email)
                       .SingleOrDefaultAsync();

    public async Task<User?> GetById(string id)
      => await _context.Users
                       .AsNoTrackingWithIdentityResolution()
                       .Where(x => x.Id == id)
                       .SingleOrDefaultAsync();

    public async Task DeleteById(string id)
    {
        var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        Console.WriteLine(user?.Id ?? "User not found");

        if (user is null)
            return;

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}
