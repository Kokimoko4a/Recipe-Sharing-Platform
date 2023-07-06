

namespace RecipesSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using RecipeSharingPlatform.Data.Models;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Recipe;

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

            builder
                .HasMany(c => c.Comments)
                .WithOne(r => r.Recipe)
                .HasForeignKey(c => c.RecipeId)
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

            builder.HasData(GenerateRecipe());
        }

        private Recipe GenerateRecipe()
        {
           

            Recipe recipe = new Recipe()
            {
                Id = Guid.Parse("3f1a2f97-f79e-44a8-8513-0a7d7c7acb9f"),
                Name = "Пиле с картофи по селски",
                Description = "Пилето почистете и измийте. Разполовете го, но го оставете цяло. В купичка сложете размекнатото краве масло, черния, червеният пипер, солта пикантината и стритата суха мащерка. Разбъркайте. Намажете хубаво пилето с получената смес. Картофите обелете и измийте. Нарежете ги по селски на едри резени. Сложете ги в тава. Нарежете на ситно кубче кромида и моркова и ги прибавете при картофите. Посолете ги, прибавете олиото и разбъркайте хубаво. Сложете пилето в средата на тавата при картофите. Сипете вода, колкото да ги покрие. Завийте с алуминиево фолио и сложете във загрята фурна на 220 градуса за около час и половина. Печете до готовност, като последните 10 минути отстраните фолиото. Накъсайте пилето на порции и сервирайте пиле с картофи. Да ви е вкусно!",
                CookingTime = 100,
                CountOfPortions = 6,
                PreparingTime = 15,
                CategoryId = 5,
                CookingTypeId = 14,
                DifficultyId = 3,
                ImageUrl = "https://www.google.com/search?q=chicken+with+potatoes&tbm=isch&ved=2ahUKEwj_kPr9mfn_AhWa76QKHS4eAPEQ2-cCegQIABAA&oq=chicken+with+po&gs_lcp=CgNpbWcQARgAMgUIABCABDIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjIECAAQHjoECCMQJzoICAAQgAQQsQNQiw1YgDVgyj5oAHAAeACAAaoBiAHLD5IBBDAuMTaYAQCgAQGqAQtnd3Mtd2l6LWltZ8ABAQ&sclient=img&ei=fT2mZL_eB5rfkwWuvICIDw&bih=754&biw=1536&rlz=1C1GCEU_enBG996BG996#imgrc=ss8xt7oFot-aoM",
                AuthorId = Guid.Parse("499C5B1F-008E-498E-18B8-08DB7AD03031"),
                
                /*Ingredients = new HashSet<Ingredient>() { new Ingredient()
                {
                    Id = 1,
                    Name = "potato",
                    TypeMeasurement = "kg",
                    Quantity = 1.5m,
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
                } },*/
                
            };

            return recipe;
        }
    }
}
