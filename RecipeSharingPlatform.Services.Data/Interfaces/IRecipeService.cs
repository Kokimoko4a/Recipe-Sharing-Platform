

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    using RecipeSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Web.ViewModels.Home;

    public interface IRecipeService
    {
        public Task<IEnumerable<IndexViewModel>> LastSixRecipes();

    }
}
