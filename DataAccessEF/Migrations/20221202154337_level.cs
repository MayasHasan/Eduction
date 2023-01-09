using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class level : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04fc4776-e593-44eb-a3da-bc72d577c385");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39302877-bd39-4f9d-a1e2-45701945e4f4");

            migrationBuilder.AlterColumn<string>(
                name: "Level",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0630910-475c-4c9c-ae3e-75d143a28260", "d8bf3ff7-68ca-47ef-a46b-45167138fecd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d3282c2-8c9b-4b5d-90a1-087a3bcc7401", "0364c5d5-7b59-4d5a-b929-24e6ef1cb464", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d3282c2-8c9b-4b5d-90a1-087a3bcc7401");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0630910-475c-4c9c-ae3e-75d143a28260");

            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39302877-bd39-4f9d-a1e2-45701945e4f4", "92bd38e6-1ae8-462d-a7f2-2cce3f17a493", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04fc4776-e593-44eb-a3da-bc72d577c385", "a69d2782-645b-4308-a763-b7bea3787f1b", "Admin", "ADMINISTRATOR" });
        }
    }
}
