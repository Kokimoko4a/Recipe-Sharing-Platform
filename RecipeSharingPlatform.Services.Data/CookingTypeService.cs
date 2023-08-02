


namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.CookingType;
    using RecipesSharingPlatform.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CookingTypeService : ICookingTypeService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public CookingTypeService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<string>> AllCookingTypeNamesAsync()
        {
            IEnumerable<string> cookingTypeNames = await data.CookingTypes.Select(c => c.Name).ToArrayAsync();

            return cookingTypeNames;
        }

        public async Task<bool> ExistsById(int id)
        {
            return await data.CookingTypes.AnyAsync(c => c.Id == id);
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

        public async Task<IEnumerable<CookingTypeSmallViewModel>> GetAllCookingTypesAsViewModelsAsync()
        {
            IEnumerable<CookingTypeSmallViewModel> cookingTypes = await data.CookingTypes.Skip(1).Select(c => new CookingTypeSmallViewModel()
            {
                Name = c.Name,
                Id = c.Id
            }).ToArrayAsync();

            return cookingTypes;
        }

        public async Task<CookingTypeBigViewModel> GetCookingTypeByIdAsync(int id)
        {
            CookingType cookingType = await data.CookingTypes.FirstOrDefaultAsync(c => c.Id == id);

            if (cookingType == null)
            {
                throw new ArgumentNullException();
            }

            CookingTypeBigViewModel cookingTypeBigViewModel = new CookingTypeBigViewModel();

            cookingTypeBigViewModel.Description = cookingType!.Description!;
            cookingTypeBigViewModel.Name = cookingType.Name;
            cookingTypeBigViewModel.ImageUrl = cookingType.ImageUrl;

            return cookingTypeBigViewModel;
        }
    }
}