using LeaveManagementSystem.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "3f75f1fc-b274-4e95-88e0-554cb22b234b",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp = "0629c37a-6646-40c1-89e5-a55cc26ee53d"
                },
                new IdentityRole
                {
                    Id = "9e9044e5-0543-4a4e-91e8-b7b4583fea8e",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR",
                    ConcurrencyStamp = "5fe60fcd-b254-48c7-a368-fde49d086831"
                },
                new IdentityRole
                {
                    Id = "9732ddc2-9fe5-4244-a80c-7c3feccdff46",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "c71e9d5f-afe5-47bf-8626-99fcfe0eaf9c"
                }
            );
            builder.Entity<ApplicationUser>().HasData(
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
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "9732ddc2-9fe5-4244-a80c-7c3feccdff46",
                    UserId = "29e5d4f5-34d6-47bf-acde-fe3b4f5c1331"
                } 
            );
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}

