

namespace RecipesSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RecipeSharingPlatform.Data.Models;
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            throw new NotImplementedException();
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category = new Category()
            {
                Name = "Soups",
                Id = 1
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Meals with pork"
            };
            
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Meals with lamb"
            };

            category = new Category()
            {
                Id = 4,
                Name = "Meals with beef"
            };
        }
    }
}
