using Expenses.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expenses.Infrastructure.Configurations;

public class IdentityApplicationUserConfiguration : IEntityTypeConfiguration<IdentityApplicationUser>
{
    public void Configure(EntityTypeBuilder<IdentityApplicationUser> builder)
    {
        builder.HasOne(e => e.User)
            .WithOne()
            .HasForeignKey<IdentityApplicationUser>(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Navigation(e => e.User).AutoInclude();
    }
}