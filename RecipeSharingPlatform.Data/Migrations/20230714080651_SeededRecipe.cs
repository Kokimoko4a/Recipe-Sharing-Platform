using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingPlatform.Data.Migrations
{
    public partial class SeededRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CookingTime", "CookingTypeId", "CountOfPortions", "CreatedOn", "Description", "DifficultyId", "ImageUrl", "PreparingTime", "Title", "TotalTime" },
                values: new object[] { new Guid("519453b3-fe82-4528-a70b-14be52c80dfb"), new Guid("72095eff-7d9a-4f5d-b84a-7be5e8703865"), 5, 100, 14, 6, new DateTime(2023, 7, 14, 11, 6, 51, 520, DateTimeKind.Local).AddTicks(4629), "Пилето почистете и измийте. Разполовете го, но го оставете цяло. В купичка сложете размекнатото краве масло, черния, червеният пипер, солта пикантината и стритата суха мащерка. Разбъркайте. Намажете хубаво пилето с получената смес. Картофите обелете и измийте. Нарежете ги по селски на едри резени. Сложете ги в тава. Нарежете на ситно кубче кромида и моркова и ги прибавете при картофите. Посолете ги, прибавете олиото и разбъркайте хубаво. Сложете пилето в средата на тавата при картофите. Сипете вода, колкото да ги покрие. Завийте с алуминиево фолио и сложете във загрята фурна на 220 градуса за около час и половина. Печете до готовност, като последните 10 минути отстраните фолиото. Накъсайте пилето на порции и сервирайте пиле с картофи. Да ви е вкусно!", 3, "https://www.simplyrecipes.com/thmb/e9uYiUCjh79zFsVWlkbIxR3L5Dw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2016__10__2016-10-31-OnePanChickenThighs-6-c360034c6ca5479fadffa7e92d288fe0.jpg", 15, "Пиле с картофи по селски", 115 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("519453b3-fe82-4528-a70b-14be52c80dfb"));
        }
    }
}
