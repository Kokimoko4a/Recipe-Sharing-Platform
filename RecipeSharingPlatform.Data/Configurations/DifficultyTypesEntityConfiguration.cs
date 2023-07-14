

namespace RecipesSharingPlatform.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RecipesSharingPlatform.Data.Models;

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