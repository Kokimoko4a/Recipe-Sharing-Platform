


namespace RecipesSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RecipesSharingPlatform.Data.Models;

    public class IngredientRecipeConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.
                 HasOne(i => i.Recipe)
                 .WithMany(r => r.Ingredients)
                 .HasForeignKey(i => i.RecipeId)
                 .OnDelete(DeleteBehavior.Restrict);

          
        }

    }
}