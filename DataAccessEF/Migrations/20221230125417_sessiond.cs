using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class sessiond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64fb30f4-ae6f-42de-b282-cb09b690f234");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d529c117-ded3-428e-a517-e167c2868a49");

            migrationBuilder.RenameColumn(
                name: "SessionNumber",
                table: "Sessions",
                newName: "SessionTitle");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "600c85fb-731c-4805-a40c-c538b2e46970", "db75373d-079b-445a-8ce2-669ac337a82b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "75f9e96e-533f-4ae3-8d52-6fa451e21070", "1e7bc208-cb9a-48d5-b6a5-2b190ea2bf0e", "Admin", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_SessionId",
                table: "Files",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Sessions_SessionId",
                table: "Files",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Sessions_SessionId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_SessionId",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "600c85fb-731c-4805-a40c-c538b2e46970");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75f9e96e-533f-4ae3-8d52-6fa451e21070");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "SessionTitle",
                table: "Sessions",
                newName: "SessionNumber");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d529c117-ded3-428e-a517-e167c2868a49", "cb7a1b73-a702-4ddf-9099-c195a17f7446", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64fb30f4-ae6f-42de-b282-cb09b690f234", "332c90e6-2a3a-46a2-8198-e7df3c1bc95f", "Admin", "ADMINISTRATOR" });
        }
    }
}
