using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TrainingPlannerAppMVC.Infrastructure.Seeds;

public static class SampleRoleData
{
    public static void SeedSampleRolesData(this ModelBuilder builder)
    {
        builder.Entity<IdentityRole<Guid>>(x =>
        {
            x.HasData(new IdentityRole<Guid>() { Id = Guid.NewGuid() ,Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "1"});
            x.HasData(new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = "2"});
        });
    }
}