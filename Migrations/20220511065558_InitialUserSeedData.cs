using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailAPI.Migrations
{
    public partial class InitialUserSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "admin_role", "804b610e-26e9-46c6-893d-a9cc150751d8", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "3ee042d4-6c31-4045-a571-449d567b298a", "retailapi@gmail.com", true, false, null, null, "RETAILAPI", "AQAAAAEAACcQAAAAEEQx2trbhDXE8Kr9BkbrQvmVWvf+bsTh9Dvfhd9EXESNTu695y7q6/AFeAuL36Kqxw==", null, false, "6191ce93-2c1e-4ab3-8772-7b0fede9dd51", false, "retailapi" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin_role", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin_role", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin_role");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
