using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeSharingPlatform.Data.Migrations
{
    public partial class ReturnedToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*  migrationBuilder.CreateTable(
                  name: "AspNetRoles",
                  columns: table => new
                  {
                      Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                      NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                      ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                  });

              migrationBuilder.CreateTable(
                  name: "AspNetUsers",
                  columns: table => new
                  {
                      Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                      NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                      Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                      NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                      EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                      PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                      TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                      LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                      LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                      AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                  });

              migrationBuilder.CreateTable(
                  name: "Categories",
                  columns: table => new
                  {
                      Id = table.Column<int>(type: "int", nullable: false)
                          .Annotation("SqlServer:Identity", "1, 1"),
                      Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_Categories", x => x.Id);
                  });

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

              migrationBuilder.CreateTable(
                  name: "AspNetRoleClaims",
                  columns: table => new
                  {
                      Id = table.Column<int>(type: "int", nullable: false)
                          .Annotation("SqlServer:Identity", "1, 1"),
                      RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                      table.ForeignKey(
                          name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                          column: x => x.RoleId,
                          principalTable: "AspNetRoles",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Cascade);
                  });

              migrationBuilder.CreateTable(
                  name: "AspNetUserClaims",
                  columns: table => new
                  {
                      Id = table.Column<int>(type: "int", nullable: false)
                          .Annotation("SqlServer:Identity", "1, 1"),
                      UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                      table.ForeignKey(
                          name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                          column: x => x.UserId,
                          principalTable: "AspNetUsers",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Cascade);
                  });

              migrationBuilder.CreateTable(
                  name: "AspNetUserLogins",
                  columns: table => new
                  {
                      LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                      ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                      ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                      UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                      table.ForeignKey(
                          name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                          column: x => x.UserId,
                          principalTable: "AspNetUsers",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Cascade);
                  });

              migrationBuilder.CreateTable(
                  name: "AspNetUserRoles",
                  columns: table => new
                  {
                      UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                      table.ForeignKey(
                          name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                          column: x => x.RoleId,
                          principalTable: "AspNetRoles",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Cascade);
                      table.ForeignKey(
                          name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                          column: x => x.UserId,
                          principalTable: "AspNetUsers",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Cascade);
                  });

              migrationBuilder.CreateTable(
                  name: "AspNetUserTokens",
                  columns: table => new
                  {
                      UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                      Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                      Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                      table.ForeignKey(
                          name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                          column: x => x.UserId,
                          principalTable: "AspNetUsers",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Cascade);
                  });

              migrationBuilder.CreateTable(
                  name: "Recipes",
                  columns: table => new
                  {
                      Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                      Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                      CookingTime = table.Column<int>(type: "int", nullable: false),
                      CountOfPortions = table.Column<int>(type: "int", nullable: false),
                      PreparingTime = table.Column<int>(type: "int", nullable: false),
                      TotalTime = table.Column<int>(type: "int", nullable: false),
                      CategoryId = table.Column<int>(type: "int", nullable: false),
                      CookingTypeId = table.Column<int>(type: "int", nullable: false),
                      DifficultyId = table.Column<int>(type: "int", nullable: false),
                      ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                      AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                      CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_Recipes", x => x.Id);
                      table.ForeignKey(
                          name: "FK_Recipes_AspNetUsers_AuthorId",
                          column: x => x.AuthorId,
                          principalTable: "AspNetUsers",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Restrict);
                      table.ForeignKey(
                          name: "FK_Recipes_Categories_CategoryId",
                          column: x => x.CategoryId,
                          principalTable: "Categories",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Restrict);
                      table.ForeignKey(
                          name: "FK_Recipes_CookingTypes_CookingTypeId",
                          column: x => x.CookingTypeId,
                          principalTable: "CookingTypes",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Restrict);
                      table.ForeignKey(
                          name: "FK_Recipes_DifficultyTypes_DifficultyId",
                          column: x => x.DifficultyId,
                          principalTable: "DifficultyTypes",
                          principalColumn: "Id",
                          onDelete: ReferentialAction.Restrict);
                  });

             */

            migrationBuilder.AlterColumn<decimal>(
      name: "Quantity",
      table: "Ingredients",
      type: "decimal(18,2)",
      nullable: false,
      oldClrType: typeof(decimal),
      oldType: "decimal(18,0)"
  );

        }

        /*   migrationBuilder.CreateTable(
               name: "Ingredients",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                   Quantity = table.Column<double>(type: "float", nullable: false),
                   TypeMeasurement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                   RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Ingredients", x => x.Id);
                   table.ForeignKey(
                       name: "FK_Ingredients_Recipes_RecipeId",
                       column: x => x.RecipeId,
                       principalTable: "Recipes",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Restrict);
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
               name: "IX_AspNetRoleClaims_RoleId",
               table: "AspNetRoleClaims",
               column: "RoleId");

           migrationBuilder.CreateIndex(
               name: "RoleNameIndex",
               table: "AspNetRoles",
               column: "NormalizedName",
               unique: true,
               filter: "[NormalizedName] IS NOT NULL");

           migrationBuilder.CreateIndex(
               name: "IX_AspNetUserClaims_UserId",
               table: "AspNetUserClaims",
               column: "UserId");

           migrationBuilder.CreateIndex(
               name: "IX_AspNetUserLogins_UserId",
               table: "AspNetUserLogins",
               column: "UserId");

           migrationBuilder.CreateIndex(
               name: "IX_AspNetUserRoles_RoleId",
               table: "AspNetUserRoles",
               column: "RoleId");

           migrationBuilder.CreateIndex(
               name: "EmailIndex",
               table: "AspNetUsers",
               column: "NormalizedEmail");

           migrationBuilder.CreateIndex(
               name: "UserNameIndex",
               table: "AspNetUsers",
               column: "NormalizedUserName",
               unique: true,
               filter: "[NormalizedUserName] IS NOT NULL");

           migrationBuilder.CreateIndex(
               name: "IX_Ingredients_RecipeId",
               table: "Ingredients",
               column: "RecipeId");

           migrationBuilder.CreateIndex(
               name: "IX_Recipes_AuthorId",
               table: "Recipes",
               column: "AuthorId");

           migrationBuilder.CreateIndex(
               name: "IX_Recipes_CategoryId",
               table: "Recipes",
               column: "CategoryId");

           migrationBuilder.CreateIndex(
               name: "IX_Recipes_CookingTypeId",
               table: "Recipes",
               column: "CookingTypeId");

           migrationBuilder.CreateIndex(
               name: "IX_Recipes_DifficultyId",
               table: "Recipes",
               column: "DifficultyId");
       }*/

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CookingTypes");

            migrationBuilder.DropTable(
                name: "DifficultyTypes");
        }
    }
}
