using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesSharingPlatform.Data.Migrations
{
    public partial class SeededRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TypeMeasurement",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Ingredients",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CookingTime", "CookingTypeId", "CountOfPortions", "Description", "DifficultyId", "ImageUrl", "Name", "PreparingTime" },
                values: new object[] { new Guid("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f"), new Guid("499c5b1f-008e-498e-18b8-08db7ad03031"), 5, 100, 14, 6, "Пилето почистете и измийте. Разполовете го, но го оставете цяло. В купичка сложете размекнатото краве масло, черния, червеният пипер, солта пикантината и стритата суха мащерка. Разбъркайте. Намажете хубаво пилето с получената смес. Картофите обелете и измийте. Нарежете ги по селски на едри резени. Сложете ги в тава. Нарежете на ситно кубче кромида и моркова и ги прибавете при картофите. Посолете ги, прибавете олиото и разбъркайте хубаво. Сложете пилето в средата на тавата при картофите. Сипете вода, колкото да ги покрие. Завийте с алуминиево фолио и сложете във загрята фурна на 220 градуса за около час и половина. Печете до готовност, като последните 10 минути отстраните фолиото. Накъсайте пилето на порции и сервирайте пиле с картофи. Да ви е вкусно!", 3, "https://www.google.com/search?q=chicken+with+potatoes&tbm=isch&ved=2ahUKEwj_kPr9mfn_AhWa76QKHS4eAPEQ2-cCegQIABAA&oq=chicken+with+po&gs_lcp=CgNpbWcQARgAMgUIABCABDIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjoECCMQJzoICAAQgAQQsQNQiw1YgDVgyj5oAHAAeACAAaoBiAHLD5IBBDAuMTaYAQCgAQGqAQtnd3Mtd2l6LWltZ8ABAQ&sclient=img&ei=fT2mZL_eB5rfkwWuvICIDw&bih=754&biw=1536&rlz=1C1GCEU_enBG996BG996#imgrc=ss8xt7oFot-aoM", "Пиле с картофи по селски", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f"));

            migrationBuilder.AlterColumn<string>(
                name: "TypeMeasurement",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Ingredients",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
