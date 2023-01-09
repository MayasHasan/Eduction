using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class joinedteacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f010ddd1-b5ca-45c9-8b6a-54da4d01654e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7cde7f9-a908-44a1-b8b7-d959de803676");

            migrationBuilder.RenameColumn(
                name: "specialization",
                table: "Teachers",
                newName: "Specialization");

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedDate",
                table: "Teachers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b78319d2-f662-4490-888c-9ba7b04879fb", "f3542f91-061f-4525-970b-9d7bf954d0b9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "78356f3a-eacd-437e-998c-26b13bdeb372", "45714664-3a21-4967-a740-256960464cc3", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78356f3a-eacd-437e-998c-26b13bdeb372");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b78319d2-f662-4490-888c-9ba7b04879fb");

            migrationBuilder.DropColumn(
                name: "JoinedDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Teachers",
                newName: "specialization");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f010ddd1-b5ca-45c9-8b6a-54da4d01654e", "52bff32f-3e81-432a-ab15-297948e9280b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7cde7f9-a908-44a1-b8b7-d959de803676", "0307ba3c-078b-4707-8635-9aff59aaad48", "Admin", "ADMINISTRATOR" });
        }
    }
}
