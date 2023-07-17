

using RecipeSharingPlatform.Web.ViewModels.Category;

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    public interface ICategoryService
    {
         Task<IEnumerable<RecipeCategorySelectFormModel>> GetAllCategoriesAsync();

         Task<bool> ExistsById(int id);

        Task<IEnumerable<string>> AllCategoryNamesAsync();


    }
}