

namespace RecipesSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using RecipeSharingPlatform.Data.Models;
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
        }

      /*  private Recipe[] GenerateRecipes()
        {
            ICollection<Recipe> recipes = new HashSet<Recipe>();

            Recipe recipe = new Recipe()
            {
                
            };
        }*/
    }
}
