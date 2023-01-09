using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class stu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5387701-1781-45e3-952f-9bf8a7d7d404");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f12e3f9b-25fe-4156-bfd1-2e21f6f2f93e");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedDate",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "208ed982-055d-43aa-bac5-16dfad698d6d", "0f96fc44-b98d-4697-8f78-5bf1a8174dc1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "beffce61-f417-40d8-9909-9783f0469dc5", "4665a1a5-d937-4435-9bc6-f19a509f4f69", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "208ed982-055d-43aa-bac5-16dfad698d6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beffce61-f417-40d8-9909-9783f0469dc5");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "JoinedDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Students");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5387701-1781-45e3-952f-9bf8a7d7d404", "f29262a6-edcc-4350-b4d1-ea50e3092930", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f12e3f9b-25fe-4156-bfd1-2e21f6f2f93e", "c452906c-c95b-427c-ad18-85d0d2f1cd0a", "Admin", "ADMINISTRATOR" });
        }
    }
}
