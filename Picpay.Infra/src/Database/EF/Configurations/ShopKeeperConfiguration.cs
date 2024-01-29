using Picpay.Domain.Features.Mercant.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Picpay.Infra.Database.EF.Configurations;

public class ShopKeeperConfiguration : IEntityTypeConfiguration<ShopKeeper>
{
    public void Configure(EntityTypeBuilder<ShopKeeper> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Id).HasMaxLength(40);

        builder.Property(x => x.Fullname).HasMaxLength(128).IsRequired();

        builder.Property(x => x.HashedPassword).HasMaxLength(128).IsRequired();
        builder.Property(x => x.Salt).HasMaxLength(128).IsRequired();

        builder.Property(x => x.CPF).HasMaxLength(11).IsRequired();
        builder.HasIndex(x => x.CPF).IsUnique();

        builder.Property(x => x.Email).HasMaxLength(255).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.ToTable(t => t.HasCheckConstraint("CK_Users_Balance", @"""Balance"" > 0"));
    }
}
