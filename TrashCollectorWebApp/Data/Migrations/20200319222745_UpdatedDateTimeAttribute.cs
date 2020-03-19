using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorWebApp.Data.Migrations
{
    public partial class UpdatedDateTimeAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88b5412e-3cc3-4096-9cc7-c3fcc9fea7d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d22a8f2-08ef-427a-a1b3-116890c1d9fc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27633bf2-e28f-45c8-9782-a7866af1baf7", "1b750904-ad75-4601-9189-357380957da5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3fcf734f-fa79-465b-bf36-a2d98fd39117", "daade324-20e8-43b6-8483-7c63fe8fe9ed", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27633bf2-e28f-45c8-9782-a7866af1baf7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fcf734f-fa79-465b-bf36-a2d98fd39117");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88b5412e-3cc3-4096-9cc7-c3fcc9fea7d9", "ad957b32-d70b-49aa-9b40-55082e02ebc9", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8d22a8f2-08ef-427a-a1b3-116890c1d9fc", "10e5c81a-3a0f-4014-bc17-e3a0684881ea", "Employee", "EMPLOYEE" });
        }
    }
}
