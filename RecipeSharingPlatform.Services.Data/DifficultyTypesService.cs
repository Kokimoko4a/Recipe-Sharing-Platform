


namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform_2.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.DifficultyType;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class DifficultyTypesService : IDifficultyTypesService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public DifficultyTypesService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<RecipeDifficultyTypeSelectFormModel>> GetAllDifficultyTypesAsync()
        {
            IEnumerable<RecipeDifficultyTypeSelectFormModel> recipeDifficultyTypes = await data.DifficultyTypes.
                Select(d => new RecipeDifficultyTypeSelectFormModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                })
                .AsNoTracking()
                .ToArrayAsync();

            return recipeDifficultyTypes;
        }
    }
}
