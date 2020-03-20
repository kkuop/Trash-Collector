using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorWebApp.Migrations
{
    public partial class AddedColumnsToCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37b19310-d949-4dc7-9a63-6b035bb3743a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72e06336-2fe2-4ca4-943f-fc03fa0a8c2b");

            migrationBuilder.AddColumn<bool>(
                name: "isExtraPickUpDateSet",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isTemporarySuspendSet",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "564a4da6-6057-4fd7-9389-33dfa252e5e3", "ff12ab11-5b65-4b04-98d1-22f87121c3cf", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5836fb0f-e865-4054-8b80-91165b4a07bd", "0a534005-64b1-44d3-b7ca-b3b009adbcd2", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "564a4da6-6057-4fd7-9389-33dfa252e5e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5836fb0f-e865-4054-8b80-91165b4a07bd");

            migrationBuilder.DropColumn(
                name: "isExtraPickUpDateSet",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "isTemporarySuspendSet",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37b19310-d949-4dc7-9a63-6b035bb3743a", "0eb547ae-ae79-49e2-9baa-420cbd2f8ef0", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72e06336-2fe2-4ca4-943f-fc03fa0a8c2b", "13fb9e6f-af42-41f8-8885-1b3a89b2ce77", "Employee", "EMPLOYEE" });
        }
    }
}
