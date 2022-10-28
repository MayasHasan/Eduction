using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class filessss : Migration
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5798280c-0ebb-48cc-a9aa-8fd4e201af5b", "791b033d-1ab7-4fae-bb6c-2a29308953cb", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0929c078-6d02-4ab7-b7a7-075e044fadff", "2475324b-8c3f-4e8f-bb4a-aeffef29c5f7", "Admin", "ADMINISTRATOR" });

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
                keyValue: "0929c078-6d02-4ab7-b7a7-075e044fadff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5798280c-0ebb-48cc-a9aa-8fd4e201af5b");

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
    }
}
