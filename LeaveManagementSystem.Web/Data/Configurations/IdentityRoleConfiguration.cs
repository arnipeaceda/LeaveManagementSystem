using LeaveManagementSystem.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
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
        }
    }
}
