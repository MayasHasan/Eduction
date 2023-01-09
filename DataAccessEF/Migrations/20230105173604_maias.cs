using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class maias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "600c85fb-731c-4805-a40c-c538b2e46970");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75f9e96e-533f-4ae3-8d52-6fa451e21070");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b314af8b-b39f-4b9f-b241-b97cc5607533", "5e515e51-7a5d-47e3-b326-e139db195084", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2548fb9d-f804-4769-aa96-0deaa797bf2c", "3e28649a-4a42-42d9-9b87-f42ca937193f", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2548fb9d-f804-4769-aa96-0deaa797bf2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b314af8b-b39f-4b9f-b241-b97cc5607533");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "600c85fb-731c-4805-a40c-c538b2e46970", "db75373d-079b-445a-8ce2-669ac337a82b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75f9e96e-533f-4ae3-8d52-6fa451e21070", "1e7bc208-cb9a-48d5-b6a5-2b190ea2bf0e", "Admin", "ADMINISTRATOR" });
        }
    }
}
