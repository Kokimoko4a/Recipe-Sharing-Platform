

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    using RecipesSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Web.ViewModels.Home;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;

    public interface IRecipeService
    {
        public Task<IEnumerable<IndexViewModel>> LastSixRecipesAsync();

        public Task<IEnumerable<RecipeViewModel>> AllRecipesAsync();

        public Task<Recipe> GetRecipeByIdAsync(Guid id);

        public Task CreateRecipeAsync(RecipeFormModel recipeFormModel, string userId);

    }
}