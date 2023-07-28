namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    using RecipeSharingPlatform.Web.ViewModels.CookingType;

    public interface ICookingTypeService
    {
         Task<IEnumerable<RecipeCookingTypeSelectFormModel>> GetAllCookingTypesAsync();

         Task<bool> ExistsById(int id);

        Task<IEnumerable<string>> AllCookingTypeNamesAsync();

        Task<IEnumerable<CookingTypeSmallViewModel>> GetAllCookingTypesAsViewModelsAsync();

        Task<CookingTypeBigViewModel> GetCookingTypeByIdAsync(int id);

    }
}