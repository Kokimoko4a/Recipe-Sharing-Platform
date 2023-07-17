

namespace RecipesSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using RecipesSharingPlatform.Data.Models;

    public class RecipeEntityConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(i => i.Ingredients)
                .WithOne(r => r.Recipe)
                .HasForeignKey(r => r.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.
                HasOne(r => r.Author)
                .WithMany(r => r.Recipes)
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.
                HasOne(r => r.CookingType)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CookingTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.
                HasOne(r => r.Difficulty)
                .WithMany(d => d.Recipes)
                .HasForeignKey(r => r.DifficultyId)
                .OnDelete(DeleteBehavior.Restrict);

           // builder.HasData(GenerateRecipe());
        }

       /* private Recipe GenerateRecipe()
        {


            Recipe recipe = new Recipe()
            {
                Id = Guid.NewGuid(),
                Title = "Пиле с картофи по селски",
                Description = "Пилето почистете и измийте. Разполовете го, но го оставете цяло. В купичка сложете размекнатото краве масло, черния, червеният пипер, солта пикантината и стритата суха мащерка. Разбъркайте. Намажете хубаво пилето с получената смес. Картофите обелете и измийте. Нарежете ги по селски на едри резени. Сложете ги в тава. Нарежете на ситно кубче кромида и моркова и ги прибавете при картофите. Посолете ги, прибавете олиото и разбъркайте хубаво. Сложете пилето в средата на тавата при картофите. Сипете вода, колкото да ги покрие. Завийте с алуминиево фолио и сложете във загрята фурна на 220 градуса за около час и половина. Печете до готовност, като последните 10 минути отстраните фолиото. Накъсайте пилето на порции и сервирайте пиле с картофи. Да ви е вкусно!",
                CookingTime = 100,
                CountOfPortions = 6,
                PreparingTime = 15,
                CategoryId = 5,
                CookingTypeId = 14,
                DifficultyId = 3,
                ImageUrl = "https://www.simplyrecipes.com/thmb/e9uYiUCjh79zFsVWlkbIxR3L5Dw=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__simply_recipes__uploads__2016__10__2016-10-31-OnePanChickenThighs-6-c360034c6ca5479fadffa7e92d288fe0.jpg",
                AuthorId = Guid.Parse("72095EFF-7D9A-4F5D-B84A-7BE5E8703865"),

                 /*Ingredients = new HashSet<Ingredient>() { new Ingredient()
                 {
                     Id = 1,
                     Name = "potato",
                     TypeMeasurement = "kg",
                     Quantity = 1,
                     RecipeId = Guid.Parse("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f")
                 },
                 new Ingredient()
                 { 
                     Id = 2,
                     Name = "chicken",
                     Quantity = 1,
                     RecipeId = Guid.Parse("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f")
                 },
                 new Ingredient()
                 { 
                     Id = 3,
                     Name = "oil",
                     TypeMeasurement = "gr",
                     Quantity = 50,
                     RecipeId = Guid.Parse("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f")
                 } }

            };

            return recipe;
        }*/
    }
}