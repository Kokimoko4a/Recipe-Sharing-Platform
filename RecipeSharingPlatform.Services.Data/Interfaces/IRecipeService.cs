

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    using RecipesSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Web.ViewModels.Home;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    using RecipeSharingPlatform.Services.Data.Models.Recipe;

    public interface IRecipeService
    {
        Task<IEnumerable<IndexViewModel>> LastSixRecipesAsync();

        Task<IEnumerable<RecipeViewModel>> AllRecipesAsync();

         Task<Recipe> GetRecipeByIdAsync(Guid id);

         Task CreateRecipeAsync(RecipeFormModel recipeFormModel, string userId);

        public Task<AllRecipesFilteredAndPagedServiceModel> AllFilteredAsync(AllRecipesQueryModel queryModel);

    }
}