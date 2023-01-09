using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class img : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3282c2-8c9b-4b5d-90a1-087a3bcc7401");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0630910-475c-4c9c-ae3e-75d143a28260");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0e21bd63-7e23-4775-953c-7447b2b85a8a", "b8b6978d-ae57-487a-9cf7-6d05df14f9c1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb520f70-ca0f-4488-87a6-0bceae4a058c", "c221fb4b-6a08-48ea-badd-426a98065194", "Admin", "ADMINISTRATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseId",
                table: "Files",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CourseId",
                table: "Files");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e21bd63-7e23-4775-953c-7447b2b85a8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb520f70-ca0f-4488-87a6-0bceae4a058c");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Files");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0630910-475c-4c9c-ae3e-75d143a28260", "d8bf3ff7-68ca-47ef-a46b-45167138fecd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d3282c2-8c9b-4b5d-90a1-087a3bcc7401", "0364c5d5-7b59-4d5a-b929-24e6ef1cb464", "Admin", "ADMINISTRATOR" });
        }
    }
}
