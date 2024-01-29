using Picpay.Domain.Features.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Picpay.Domain.Features.Mercant.Entities;
using Picpay.Domain.Features.Transfer.Entities;

namespace Picpay.Infra.Database.EF.Contexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; } = default!;
    public DbSet<ShopKeeper> ShopKeepers { get; set; } = default!;
    public DbSet<TransactionEntity> Transations { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
