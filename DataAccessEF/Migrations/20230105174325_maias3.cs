using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class maias3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2548fb9d-f804-4769-aa96-0deaa797bf2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b314af8b-b39f-4b9f-b241-b97cc5607533");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03f31544-120b-4832-a976-55bc433cf221", "843bb19f-54a7-4ade-ae84-3434e7070315", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "572afb1d-b73c-4b9d-a0e7-ff98a7495137", "738956f1-af3d-48ff-8dbe-c5911e409f15", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03f31544-120b-4832-a976-55bc433cf221");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "572afb1d-b73c-4b9d-a0e7-ff98a7495137");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Teachers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b314af8b-b39f-4b9f-b241-b97cc5607533", "5e515e51-7a5d-47e3-b326-e139db195084", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2548fb9d-f804-4769-aa96-0deaa797bf2c", "3e28649a-4a42-42d9-9b87-f42ca937193f", "Admin", "ADMINISTRATOR" });
        }
    }
}
