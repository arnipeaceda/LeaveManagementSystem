using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoledAndAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f75f1fc-b274-4e95-88e0-554cb22b234b", "0629c37a-6646-40c1-89e5-a55cc26ee53d", "Employee", "EMPLOYEE" },
                    { "9732ddc2-9fe5-4244-a80c-7c3feccdff46", "c71e9d5f-afe5-47bf-8626-99fcfe0eaf9c", "Administrator", "ADMINISTRATOR" },
                    { "9e9044e5-0543-4a4e-91e8-b7b4583fea8e", "5fe60fcd-b254-48c7-a368-fde49d086831", "Supervisor", "SUPERVISOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "29e5d4f5-34d6-47bf-acde-fe3b4f5c1331", 0, "ab231182-14a7-44af-8e2d-d7b486e21da8", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAELAz+VL8YDLxAueZFxoSmp1CWAOm8aMZXTJex25lxeb0g8FYRoC2nfyDAW44IWeY4A==", null, false, "8e5347aa-4ef7-4eb3-bffb-4956d4c8ee4c", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9732ddc2-9fe5-4244-a80c-7c3feccdff46", "29e5d4f5-34d6-47bf-acde-fe3b4f5c1331" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f75f1fc-b274-4e95-88e0-554cb22b234b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e9044e5-0543-4a4e-91e8-b7b4583fea8e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9732ddc2-9fe5-4244-a80c-7c3feccdff46", "29e5d4f5-34d6-47bf-acde-fe3b4f5c1331" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9732ddc2-9fe5-4244-a80c-7c3feccdff46");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29e5d4f5-34d6-47bf-acde-fe3b4f5c1331");
        }
    }
}
