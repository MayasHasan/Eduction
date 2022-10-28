using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class fg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0929c078-6d02-4ab7-b7a7-075e044fadff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5798280c-0ebb-48cc-a9aa-8fd4e201af5b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29cd7b5e-687f-4c6e-9747-c3dea32fb45f", "c83e8dca-8099-49f1-9a52-c0ab1927f2cd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a194af3-8f1d-40ce-9ef4-918ae64556a2", "2d39c3d3-8207-4870-a730-2246ead44493", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29cd7b5e-687f-4c6e-9747-c3dea32fb45f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a194af3-8f1d-40ce-9ef4-918ae64556a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5798280c-0ebb-48cc-a9aa-8fd4e201af5b", "791b033d-1ab7-4fae-bb6c-2a29308953cb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0929c078-6d02-4ab7-b7a7-075e044fadff", "2475324b-8c3f-4e8f-bb4a-aeffef29c5f7", "Admin", "ADMINISTRATOR" });
        }
    }
}
