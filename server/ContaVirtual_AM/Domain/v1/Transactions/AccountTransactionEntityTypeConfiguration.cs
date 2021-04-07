using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContaVirtual_AM.Domain.v1.Transactions
{
    public class AccountTransactionEntityTypeConfiguration : IEntityTypeConfiguration<AccountTransaction>
    {
        public void Configure(EntityTypeBuilder<AccountTransaction> builder)
        {
            builder.ToTable("Transactions");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.Type).IsRequired();

            builder.HasOne(r => r.Account).WithMany(p => p.Transactions).HasForeignKey(r => r.AccountId);
        }
    }
}
