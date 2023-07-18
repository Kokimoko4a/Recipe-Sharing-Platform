

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

        Task<Recipe> GetRecipeByIdAsync(string id);

        Task CreateRecipeAsync(RecipeFormModel recipeFormModel, string userId);

        Task<AllRecipesFilteredAndPagedServiceModel> AllFilteredAsync(AllRecipesQueryModel queryModel);

        Task<IEnumerable<RecipeViewModel>> GetAllRecipesByUserId(string userId);

        Task<bool> IsRecipeYours(string userId, string recipeId);

        Task<RecipeFormModel> GetRecipeAsFormModel(string recipeId);

        Task<bool> ExistsByIdAsync(string recipeId);

    }
}