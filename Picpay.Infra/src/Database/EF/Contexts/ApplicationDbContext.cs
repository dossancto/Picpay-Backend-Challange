using Picpay.Application.Features.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Picpay.Application.Features.ShopKeepers.Entities;

namespace Picpay.Infra.Database.EF.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<ShopKeeper> ShopKeepers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
