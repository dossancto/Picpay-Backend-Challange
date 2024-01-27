using Picpay.Application.Features.Users.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Picpay.Infra.Database.EF.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Id).HasMaxLength(40);

        builder.Property(x => x.Name).HasMaxLength(90).IsRequired().IsUnicode();

        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Email).HasMaxLength(90);
        builder.HasIndex(x => x.Email).IsUnique();

        builder.Property(x => x.HashedPassword).IsRequired();
        builder.Property(x => x.Salt).IsRequired();
    }
}
