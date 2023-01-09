using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class addphone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bce0df4-c641-44bc-b9f6-a7ff646ec5c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4517a81-bc22-4f00-8ff8-6d519dd4c2cb");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d529c117-ded3-428e-a517-e167c2868a49", "cb7a1b73-a702-4ddf-9099-c195a17f7446", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64fb30f4-ae6f-42de-b282-cb09b690f234", "332c90e6-2a3a-46a2-8198-e7df3c1bc95f", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64fb30f4-ae6f-42de-b282-cb09b690f234");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d529c117-ded3-428e-a517-e167c2868a49");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Students");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4517a81-bc22-4f00-8ff8-6d519dd4c2cb", "bf22d3da-63b2-45e6-ac1a-f22b8fc3f3c0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4bce0df4-c641-44bc-b9f6-a7ff646ec5c8", "5ec32b69-6ec3-4ac6-8df8-2abde60885e5", "Admin", "ADMINISTRATOR" });
        }
    }
}
