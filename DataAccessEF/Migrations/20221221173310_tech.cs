using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class tech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e21bd63-7e23-4775-953c-7447b2b85a8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb520f70-ca0f-4488-87a6-0bceae4a058c");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "specialization",
                table: "Teachers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f010ddd1-b5ca-45c9-8b6a-54da4d01654e", "52bff32f-3e81-432a-ab15-297948e9280b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7cde7f9-a908-44a1-b8b7-d959de803676", "0307ba3c-078b-4707-8635-9aff59aaad48", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f010ddd1-b5ca-45c9-8b6a-54da4d01654e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7cde7f9-a908-44a1-b8b7-d959de803676");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "specialization",
                table: "Teachers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e21bd63-7e23-4775-953c-7447b2b85a8a", "b8b6978d-ae57-487a-9cf7-6d05df14f9c1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb520f70-ca0f-4488-87a6-0bceae4a058c", "c221fb4b-6a08-48ea-badd-426a98065194", "Admin", "ADMINISTRATOR" });
        }
    }
}
