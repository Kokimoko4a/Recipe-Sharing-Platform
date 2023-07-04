using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeSharingPlatform.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesSharingPlatform.Data.Configurations
{
    public class DifficultyTypesEntityConfiguration : IEntityTypeConfiguration<DifficultyType>
    {
        public void Configure(EntityTypeBuilder<DifficultyType> builder)
        {
            builder.HasData(GenerateDifficultyTypes());
        }

        private DifficultyType[] GenerateDifficultyTypes()
        { 
            ICollection<DifficultyType> difficultyTypes = new HashSet<DifficultyType>();

            DifficultyType difficultyType = new DifficultyType()
            {
                Id = 1,
                Name = "Easy"
            };
            difficultyTypes.Add(difficultyType);

            difficultyType = new DifficultyType()
            {
                Id = 2,
                Name = "Very hard"
            };
            difficultyTypes.Add(difficultyType);

            difficultyType = new DifficultyType()
            {
                Id = 3,
                Name = "Medium hard"
            };
            difficultyTypes.Add(difficultyType);

            difficultyType = new DifficultyType()
            {
                Id = 4,
                Name = "Hard"
            };
            difficultyTypes.Add(difficultyType);

            return difficultyTypes.ToArray();
        }
    }
}
