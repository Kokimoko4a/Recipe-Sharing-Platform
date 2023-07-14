


namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.CookingType;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CookingTypeService : ICookingTypeService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public CookingTypeService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<RecipeCookingTypeSelectFormModel>> GetAllCookingTypesAsync()
        {
            IEnumerable<RecipeCookingTypeSelectFormModel> cookingTypes = await data.CookingTypes.Select(c => new RecipeCookingTypeSelectFormModel()
            {
                Id = c.Id,
                Name = c.Name,
            }).AsNoTracking()
            .ToArrayAsync();

            return cookingTypes;
        }
    }
}