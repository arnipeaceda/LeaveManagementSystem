using LeaveManagementSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                new ApplicationUser
                {
                    Id = "29e5d4f5-34d6-47bf-acde-fe3b4f5c1331",
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    PasswordHash = "AQAAAAIAAYagAAAAECilDjH/hXxSOFJcHKbyYt3FR/kwgql12nf8UvJ0esb/mbn15Sj7r09/qC/zArErTw==",
                    EmailConfirmed = true,
                    SecurityStamp = "8e5347aa-4ef7-4eb3-bffb-4956d4c8ee4c",
                    ConcurrencyStamp = "ab231182-14a7-44af-8e2d-d7b486e21da8",
                    FirstName = "Default",
                    LastName = "Admin",
                    DateOfBirth = new DateOnly(1990, 1, 1)
                }
            );
        }
    }
}
