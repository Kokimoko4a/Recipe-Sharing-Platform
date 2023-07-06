using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesSharingPlatform.Data.Migrations
{
    public partial class ChangedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalTime",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f"),
                column: "TotalTime",
                value: 115);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "Recipes");
        }
    }
}
