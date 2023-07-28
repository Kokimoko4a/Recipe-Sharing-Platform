using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingPlatform.Data.Migrations
{
    public partial class AddedOneMorePropertyAndSeededData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "CookingTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images-cdn.welcomesoftware.com/Zz04Y2U1NDc0ZjhhMTE3MmU0ZjNhMTg5ZWRhMjZkNjMzYg==/McCormick%E2%80%99s%20Guide%20to%20Using%20a%20Multi-Cooker.jpeg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.ctfassets.net/4row1hf0stvo/71uewy1Y0ryTqsFC3ymehf/3279b8bb8ec0013cac5caf1ca94d9cbf/SCCPRC507B-060-MAIN.jpg?w=500&h=399&fl=progressive&q=100&fm=jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://hips.hearstapps.com/hmg-prod/images/overhead-view-of-baking-ingredients-and-a-notepad-royalty-free-image-930086476-1546440806.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://lianaskitchen.co.uk/wp-content/uploads/blanching.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://www.allrecipes.com/thmb/9DymsEnpRFpCu30NOYkcv2jaHW8=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/GettyImages-155146092-2000-11ed7496811e4ea4b6d08ab6aee1f3b9.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "https://ichef.bbci.co.uk/food/ic/food_16x9_832/recipes/slow_cooker_roast_beef_94008_16x9.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "https://img.wonderhowto.com/img/34/59/63546388652864/0/food-hacks-guide-breading-frying-meat-perfection.w1456.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "https://www.seriouseats.com/thmb/7Cr44DF2TR0zw5mjLob0AXcRkzg=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__serious_eats__seriouseats.com__images__2016__05__20160505-sauteed-broccoli-rabe-vicky-wasik-4-40bb1d7b40914c7abe58a81a4b25e6d3.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://m.economictimes.com/thumb/msid-95457328,width-1600,height-860,resizemode-4,imgsize-78912/mmm-.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://st3.depositphotos.com/1590501/33976/i/450/depositphotos_339769698-stock-photo-steamed-mixed-vegetable-in-black.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://www.eatthis.com/wp-content/uploads/sites/4/2020/07/grilled-tri-tip-marinade.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://www.ikea.com/om/en/images/products/hemkomst-frying-pan-stainless-steel-non-stick-coating__1083707_pe859061_s5.jpg");

            migrationBuilder.UpdateData(
                table: "CookingTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://www.ikea.com/bh/en/images/products/smaksak-forced-air-oven-stainless-steel__0896144_pe713328_s5.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "CookingTypes");
        }
    }
}
