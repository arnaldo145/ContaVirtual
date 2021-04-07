using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContaVirtual_AM.Domain.v1.Accounts
{
    public class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Customer).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.OpeningDate).IsRequired();
            builder.Property(x => x.Balance).IsRequired().HasDefaultValue(0);

            builder.HasMany(p => p.Transactions).WithOne(r => r.Account).HasForeignKey(r => r.AccountId);
        }
    }
}
