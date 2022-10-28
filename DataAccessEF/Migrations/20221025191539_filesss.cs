using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class filesss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "281c62c9-f99b-4077-a5e2-cbab1ae23cde", "07dc9e92-7484-4b84-bf82-c22a5ed032bf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "789e768d-9ecb-4b45-9d2d-ed601302277d", "f5bb3bed-ea3a-4a3c-8e33-c03a14a5b608", "Admin", "ADMINISTRATOR" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "281c62c9-f99b-4077-a5e2-cbab1ae23cde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "789e768d-9ecb-4b45-9d2d-ed601302277d");

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
    }
}
