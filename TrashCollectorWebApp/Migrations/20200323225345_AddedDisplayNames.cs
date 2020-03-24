using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorWebApp.Migrations
{
    public partial class AddedDisplayNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01e5d060-92f7-49f6-b26a-28e9d7ca9826");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c6ad464-46bc-4cd3-91a2-a83ed05a69c8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c8ccb3e-d025-4df0-909f-96bd9e92f289", "47562daa-77d0-451f-8ee3-b963049f02f8", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae563b56-df24-4b84-88f5-0785459dba26", "fcc01df3-a3cf-4afa-9c28-435f4955aabe", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c8ccb3e-d025-4df0-909f-96bd9e92f289");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae563b56-df24-4b84-88f5-0785459dba26");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01e5d060-92f7-49f6-b26a-28e9d7ca9826", "902c13ca-fc50-48f0-ba66-e1c887ea2d5c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c6ad464-46bc-4cd3-91a2-a83ed05a69c8", "6f8c7515-3b11-4d7d-b2ba-f50a0f38dfca", "Employee", "EMPLOYEE" });
        }
    }
}
