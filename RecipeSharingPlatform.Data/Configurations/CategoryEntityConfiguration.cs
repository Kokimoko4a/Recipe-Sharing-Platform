

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

            categories.Add(category);.

            category = new Category()
            {
                Id = 4,
                Name = "Meals with beef"
            };

            category = new Category()
            {
                Id = 5,
                Name = "Meals with chicken"
            };

            category = new Category()
            {
                Id = 6,
                Name = "Meals with rabbit meat"
            };

            category = new Category()
            {
                Id = 7,
                Name = "Meals with duck meat"
            };

            category = new Category()
            {
                Id = 8,
                Name = "Meals with goose turkey"
            };

            category = new Category()
            {
                Id = 9,
                Name = "Desserts"
            };

            category = new Category()
            {
                Id = 10,
                Name = "Meals with fish"
            };

            category = new Category()
            {
                Id = 11,
                Name = "Seafood"
            };

            category = new Category()
            {
                Id = 12,
                Name = "Meals with beef"
            };

            category = new Category()
            {
                Id = 13,
                Name = "Pasta"
            };

            category = new Category()
            {
                Id = 14,
                Name = "Garniture"
            };

            category = new Category()
            {
                Id = 15,
                Name = "Vegetable meal"
            };

            category = new Category()
            {
                Id = 17,
                Name = "Alcohol"
            };

            category = new Category()
            {
                Id = 16,
                Name = "Cocktails"
            };

           
        }
    }
}
