using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorWebApp.Data.Migrations
{
    public partial class UpdatedDisplayFormatAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "9930923e-331d-4f5c-ab86-5ea0686d4951", "f32d887d-2ed8-4673-bc94-74508c5da37b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c03717ec-bc19-492f-a832-f56540551c9a", "67cee65c-0121-43c1-9ed4-bfe6da051c0d", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9930923e-331d-4f5c-ab86-5ea0686d4951");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c03717ec-bc19-492f-a832-f56540551c9a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27633bf2-e28f-45c8-9782-a7866af1baf7", "1b750904-ad75-4601-9189-357380957da5", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3fcf734f-fa79-465b-bf36-a2d98fd39117", "daade324-20e8-43b6-8483-7c63fe8fe9ed", "Employee", "EMPLOYEE" });
        }
    }
}
