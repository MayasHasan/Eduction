using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class televel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "208ed982-055d-43aa-bac5-16dfad698d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beffce61-f417-40d8-9909-9783f0469dc5");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4517a81-bc22-4f00-8ff8-6d519dd4c2cb", "bf22d3da-63b2-45e6-ac1a-f22b8fc3f3c0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bce0df4-c641-44bc-b9f6-a7ff646ec5c8", "5ec32b69-6ec3-4ac6-8df8-2abde60885e5", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bce0df4-c641-44bc-b9f6-a7ff646ec5c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4517a81-bc22-4f00-8ff8-6d519dd4c2cb");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Teachers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "208ed982-055d-43aa-bac5-16dfad698d6d", "0f96fc44-b98d-4697-8f78-5bf1a8174dc1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "beffce61-f417-40d8-9909-9783f0469dc5", "4665a1a5-d937-4435-9bc6-f19a509f4f69", "Admin", "ADMINISTRATOR" });
        }
    }
}
