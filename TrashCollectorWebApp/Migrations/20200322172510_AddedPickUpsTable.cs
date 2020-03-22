using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorWebApp.Migrations
{
    public partial class AddedPickUpsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "564a4da6-6057-4fd7-9389-33dfa252e5e3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5836fb0f-e865-4054-8b80-91165b4a07bd");

            migrationBuilder.CreateTable(
                name: "PickUps",
                columns: table => new
                {
                    PickUpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickUps", x => x.PickUpId);
                    table.ForeignKey(
                        name: "FK_PickUps_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickUps_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01e5d060-92f7-49f6-b26a-28e9d7ca9826", "902c13ca-fc50-48f0-ba66-e1c887ea2d5c", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c6ad464-46bc-4cd3-91a2-a83ed05a69c8", "6f8c7515-3b11-4d7d-b2ba-f50a0f38dfca", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_CustomerId",
                table: "PickUps",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PickUps_EmployeeId",
                table: "PickUps",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickUps");

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
                values: new object[] { "564a4da6-6057-4fd7-9389-33dfa252e5e3", "ff12ab11-5b65-4b04-98d1-22f87121c3cf", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5836fb0f-e865-4054-8b80-91165b4a07bd", "0a534005-64b1-44d3-b7ca-b3b009adbcd2", "Employee", "EMPLOYEE" });
        }
    }
}
