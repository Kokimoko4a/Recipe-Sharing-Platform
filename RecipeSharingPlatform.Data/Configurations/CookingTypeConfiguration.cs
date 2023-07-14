
namespace RecipesSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RecipesSharingPlatform.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class CookingTypeConfiguration : IEntityTypeConfiguration<CookingType>
    {
        public void Configure(EntityTypeBuilder<CookingType> builder)
        {
            builder.HasData(GenerateCookingTypes());
        }

        private CookingType[] GenerateCookingTypes()
        {
            ICollection<CookingType> cookingTypes = new HashSet<CookingType>();

            CookingType cookingType = new CookingType()
            {
                Id = 1,
                Name = "Without heat treatment"
            };

            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 2,
                Name = "Recipes in multicooker"
            };

            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 3,
                Name = "Recipe for Crock-Pot"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 4,
                Name = "Baking recipe"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 5,
                Name = "Blanching dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 6,
                Name = "Boiled dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 7,
                Name = "Stew dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 8,
                Name = "Breading dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 9,
                Name = "Saute dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 10,
                Name = "Microwave dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 11,
                Name = "Steamed dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 12,
                Name = "Grilled dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 13,
                Name = "Pan dish"
            };
            cookingTypes.Add(cookingType);

            cookingType = new CookingType()
            {
                Id = 14,
                Name = "Oven dish"
            };
            cookingTypes.Add(cookingType);

            return cookingTypes.ToArray();
        }
    }
}