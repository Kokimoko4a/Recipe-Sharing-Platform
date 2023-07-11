

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    using RecipeSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Web.ViewModels.Home;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;

    public interface IRecipeService
    {
        public Task<IEnumerable<IndexViewModel>> LastSixRecipesAsync();

        public Task<IEnumerable<RecipeViewModel>> AllRecipesAsync();

        public Recipe GetRecipeByIdAsync(Guid id);

    }
}
