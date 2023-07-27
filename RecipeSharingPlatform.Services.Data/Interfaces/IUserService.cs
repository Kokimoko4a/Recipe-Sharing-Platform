using RecipeSharingPlatform.Web.ViewModels.Recipe;
using RecipesSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Services.Data.Interfaces
{

    public interface IUserService
    {
        Task<string> GetNameByEmailAsync(string email);

        Task<ApplicationUser> GetUserWithCookedRecipes(string userId);

        Task AddCookedRecipe(string recipeId, string userId);

        Task<IEnumerable<RecipeViewModel>> GetCookedRecipesByUserId(string userId);
    }
}
