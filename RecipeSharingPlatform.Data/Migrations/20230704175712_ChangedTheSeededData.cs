using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesSharingPlatform.Data.Migrations
{
    public partial class ChangedTheSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Meals with beef" });
        }
    }
}
