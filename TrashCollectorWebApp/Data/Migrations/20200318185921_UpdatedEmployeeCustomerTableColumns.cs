using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorWebApp.Data.Migrations
{
    public partial class UpdatedEmployeeCustomerTableColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "467a2b0d-3abf-40af-a0ee-69fb981ddd25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0375c47-3ea2-4ccb-ae69-6a1ec52ca014");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ZIP",
                table: "Employee",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Customer",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExtraPickUpDate",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PickUpDay",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TemporarySuspendEnd",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TemporarySuspendStart",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ZIP",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "52694156-4262-4ec4-8db1-63b15866a1c0", "5ec9abc7-0daf-4637-9d0c-7822ac80291f", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "deada575-8793-4e33-b54b-7c07a017fe90", "bd2306e1-db6e-43c8-9157-39adb57fe3f5", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52694156-4262-4ec4-8db1-63b15866a1c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "deada575-8793-4e33-b54b-7c07a017fe90");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ExtraPickUpDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PickUpDay",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TemporarySuspendEnd",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TemporarySuspendStart",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ZIP",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "467a2b0d-3abf-40af-a0ee-69fb981ddd25", "34b002be-1da1-4bc7-a1aa-7a5054fb5480", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0375c47-3ea2-4ccb-ae69-6a1ec52ca014", "43ac112a-d2e8-4406-8d93-45e5d6b23208", "Employee", "EMPLOYEE" });
        }
    }
}
