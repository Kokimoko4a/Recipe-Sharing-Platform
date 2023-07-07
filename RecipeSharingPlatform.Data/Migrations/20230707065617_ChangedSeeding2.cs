using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipesSharingPlatform.Data.Migrations
{
    public partial class ChangedSeeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f"),
                column: "ImageUrl",
                value: "https://www.simplyrecipes.com/thmb/e9uYiUCjh79zFsVWlkbIxR3L5Dw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2016__10__2016-10-31-OnePanChickenThighs-6-c360034c6ca5479fadffa7e92d288fe0.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f"),
                column: "ImageUrl",
                value: "https://www.google.com/search?q=chicken+with+potatoes&tbm=isch&ved=2ahUKEwj_kPr9mfn_AhWa76QKHS4eAPEQ2-cCegQIABAA&oq=chicken+with+po&gs_lcp=CgNpbWcQARgAMgUIABCABDIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjoECCMQJzoICAAQgAQQsQNQiw1YgDVgyj5oAHAAeACAAaoBiAHLD5IBBDAuMTaYAQCgAQGqAQtnd3Mtd2l6LWltZ8ABAQ&sclient=img&ei=fT2mZL_eB5rfkwWuvICIDw&bih=754&biw=1536&rlz=1C1GCEU_enBG996BG996#imgrc=ss8xt7oFot-aoM");
        }
    }
}
