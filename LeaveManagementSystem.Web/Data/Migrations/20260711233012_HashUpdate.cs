using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class HashUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29e5d4f5-34d6-47bf-acde-fe3b4f5c1331",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECilDjH/hXxSOFJcHKbyYt3FR/kwgql12nf8UvJ0esb/mbn15Sj7r09/qC/zArErTw==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29e5d4f5-34d6-47bf-acde-fe3b4f5c1331",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELAz+VL8YDLxAueZFxoSmp1CWAOm8aMZXTJex25lxeb0g8FYRoC2nfyDAW44IWeY4A==");
        }
    }
}
