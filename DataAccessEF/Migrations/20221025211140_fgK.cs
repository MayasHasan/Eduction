using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessEF.Migrations
{
    public partial class fgK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29cd7b5e-687f-4c6e-9747-c3dea32fb45f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a194af3-8f1d-40ce-9ef4-918ae64556a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "39302877-bd39-4f9d-a1e2-45701945e4f4", "92bd38e6-1ae8-462d-a7f2-2cce3f17a493", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "04fc4776-e593-44eb-a3da-bc72d577c385", "a69d2782-645b-4308-a763-b7bea3787f1b", "Admin", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04fc4776-e593-44eb-a3da-bc72d577c385");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39302877-bd39-4f9d-a1e2-45701945e4f4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "29cd7b5e-687f-4c6e-9747-c3dea32fb45f", "c83e8dca-8099-49f1-9a52-c0ab1927f2cd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8a194af3-8f1d-40ce-9ef4-918ae64556a2", "2d39c3d3-8207-4870-a730-2246ead44493", "Admin", "ADMINISTRATOR" });
        }
    }
}
