using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class filess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_UserId1",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserId1",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "039c14d3-3164-4e7c-88ee-562be5714b03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d047d3c0-d69c-438b-804a-1a64e9ef0216");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Files",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationUserId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0e6eb2e-191e-4560-ae55-1c9e9055612f", "92f2a9f0-43e7-4dfb-9c32-10cc7188f16d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44dd9555-e527-4cdb-b004-35bc0be72286", "caa07cdb-6ebf-4797-9a43-8f9ad6a9827c", "Admin", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId",
                table: "Files",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                table: "Files",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_AspNetUsers_UserId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserId",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44dd9555-e527-4cdb-b004-35bc0be72286");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0e6eb2e-191e-4560-ae55-1c9e9055612f");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Files",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d047d3c0-d69c-438b-804a-1a64e9ef0216", "b6aa94dd-9424-49a9-a156-769117e5a332", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "039c14d3-3164-4e7c-88ee-562be5714b03", "98e2b410-9b8a-4c18-9b20-e5d062df73b3", "Admin", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserId1",
                table: "Files",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_AspNetUsers_UserId1",
                table: "Files",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
