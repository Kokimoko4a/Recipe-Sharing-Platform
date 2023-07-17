

using RecipeSharingPlatform.Web.ViewModels.Category;

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<RecipeCategorySelectFormModel>> GetAllCategoriesAsync();

        public Task<bool> ExistsById(int id);

    }
}