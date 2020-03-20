using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollectorWebApp.Migrations
{
    public partial class RemoveDayOfTheWeekTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_DaysOfTheWeek_DayOfTheWeekId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "DaysOfTheWeek");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DayOfTheWeekId",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c4c0240-8b7d-436c-a477-03c03b855201");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bec97c3b-c825-4ea5-a443-e04676425350");

            migrationBuilder.DropColumn(
                name: "DayOfTheWeekId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "DayOfTheWeek",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37b19310-d949-4dc7-9a63-6b035bb3743a", "0eb547ae-ae79-49e2-9baa-420cbd2f8ef0", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72e06336-2fe2-4ca4-943f-fc03fa0a8c2b", "13fb9e6f-af42-41f8-8885-1b3a89b2ce77", "Employee", "EMPLOYEE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37b19310-d949-4dc7-9a63-6b035bb3743a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72e06336-2fe2-4ca4-943f-fc03fa0a8c2b");

            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "DayOfTheWeekId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DaysOfTheWeek",
                columns: table => new
                {
                    DayOfTheWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfTheWeek", x => x.DayOfTheWeekId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c4c0240-8b7d-436c-a477-03c03b855201", "fdd67aaa-5ff9-40f8-8960-77647e813c76", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bec97c3b-c825-4ea5-a443-e04676425350", "84f59117-1a7c-4b07-a12c-5c47e442c517", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DayOfTheWeekId",
                table: "Customers",
                column: "DayOfTheWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_DaysOfTheWeek_DayOfTheWeekId",
                table: "Customers",
                column: "DayOfTheWeekId",
                principalTable: "DaysOfTheWeek",
                principalColumn: "DayOfTheWeekId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
