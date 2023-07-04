using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesSharingPlatform.Data.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookingType",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "RecipeType",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "CookingTypeId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DifficultyId",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CookingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Soups" },
                    { 2, "Meals with pork" },
                    { 3, "Meals with lamb" },
                    { 4, "Meals with beef" },
                    { 5, "Meals with chicken" },
                    { 6, "Meals with rabbit meat" },
                    { 7, "Meals with duck meat" },
                    { 8, "Meals with goose turkey" },
                    { 9, "Desserts" },
                    { 10, "Meals with fish" },
                    { 11, "Seafood" },
                    { 12, "Meals with beef" },
                    { 13, "Pasta" },
                    { 14, "Garniture" },
                    { 15, "Vegetable meal" },
                    { 16, "Cocktails" },
                    { 17, "Alcohol" }
                });

            migrationBuilder.InsertData(
                table: "CookingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Without heat treatment" },
                    { 2, "Recipes in multicooker" },
                    { 3, "Recipe for Crock-Pot" },
                    { 4, "Baking recipe" },
                    { 5, "Blanching dish" },
                    { 6, "Boiled dish" },
                    { 7, "Stew dish" },
                    { 8, "Breading dish" },
                    { 9, "Saute dish" },
                    { 10, "Microwave dish" },
                    { 11, "Steamed dish" },
                    { 12, "Grilled dish" },
                    { 13, "Pan dish" },
                    { 14, "Oven dish" }
                });

            migrationBuilder.InsertData(
                table: "DifficultyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Easy" },
                    { 2, "Very hard" },
                    { 3, "Medium hard" },
                    { 4, "Hard" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CookingTypeId",
                table: "Recipes",
                column: "CookingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DifficultyId",
                table: "Recipes",
                column: "DifficultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_CookingTypes_CookingTypeId",
                table: "Recipes",
                column: "CookingTypeId",
                principalTable: "CookingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_DifficultyTypes_DifficultyId",
                table: "Recipes",
                column: "DifficultyId",
                principalTable: "DifficultyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_CookingTypes_CookingTypeId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_DifficultyTypes_DifficultyId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "CookingTypes");

            migrationBuilder.DropTable(
                name: "DifficultyTypes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_CookingTypeId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_DifficultyId",
                table: "Recipes");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DropColumn(
                name: "CookingTypeId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "DifficultyId",
                table: "Recipes");

            migrationBuilder.AddColumn<string>(
                name: "CookingType",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecipeType",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
