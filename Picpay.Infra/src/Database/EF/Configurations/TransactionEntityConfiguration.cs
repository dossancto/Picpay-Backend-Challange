
using Picpay.Application.Features.Transfer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Picpay.Infra.Database.EF.Configurations;

public class TransactionEntityConfiguration : IEntityTypeConfiguration<TransactionEntity>
{
    public void Configure(EntityTypeBuilder<TransactionEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Id).HasMaxLength(40);
    }
}
