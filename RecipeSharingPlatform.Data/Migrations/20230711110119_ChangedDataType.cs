using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesSharingPlatform.Data.Migrations
{
    public partial class ChangedDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Quantity",
                table: "Ingredients",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f"),
                column: "CreatedOn",
                value: new DateTime(2023, 7, 11, 11, 1, 19, 41, DateTimeKind.Utc).AddTicks(1966));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f"),
                column: "CreatedOn",
                value: new DateTime(2023, 7, 11, 11, 0, 10, 796, DateTimeKind.Utc).AddTicks(5006));
        }
    }
}
