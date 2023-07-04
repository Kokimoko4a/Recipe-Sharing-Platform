

namespace RecipesSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RecipeSharingPlatform.Data.Models;
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(GenerateCategories());
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

            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Name = "Meals with beef"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 5,
                Name = "Meals with chicken"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 6,
                Name = "Meals with rabbit meat"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 7,
                Name = "Meals with duck meat"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 8,
                Name = "Meals with goose turkey"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 9,
                Name = "Desserts"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 10,
                Name = "Meals with fish"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 11,
                Name = "Seafood"
            };

            categories.Add(category);

            category = new Category()
            {
                Id = 13,
                Name = "Pasta"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 14,
                Name = "Garniture"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 15,
                Name = "Vegetable meal"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 17,
                Name = "Alcohol"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 16,
                Name = "Cocktails"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
