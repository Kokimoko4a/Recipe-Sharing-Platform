namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    using RecipesSharingPlatform.Data.Models;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    public class UserService : IUserService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public UserService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }



        public async Task<string> GetNameByEmailAsync(string email)
        {
            ApplicationUser user = await data.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user!.FirstName} {user.LastName}";
        }


        public async Task<ApplicationUser> GetUserWithCookedRecipes(string userId)
        {
            ApplicationUser user = await data.Users.Include(x => x.CookedRecipes).FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            return user;
        }

        public async Task AddCookedRecipe(string recipeId, string userId)
        {
            Recipe recipe = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == recipeId);

            ApplicationUser user = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            user.CookedRecipes.Add(recipe);

            await data.SaveChangesAsync();
        }

        public async Task<IEnumerable<RecipeViewModel>> GetCookedRecipesByUserId(string userId)
        {
            ApplicationUser user = await data.Users.Include(u => u.CookedRecipes).ThenInclude(x => x.Author).FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            return user!.CookedRecipes.Select(r => new RecipeViewModel()
            {
                Id = r.Id,
                AuthorName = r.Author!.Email,
                ImageURL = r.ImageUrl,
                Title = r.Title,
                CountBeenCooked = r.CountBeenCooked,
            });
        }

        public async Task RemoveCookedRecipe(string recipeId, string userId)
        {
            Recipe recipe = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == recipeId);

            ApplicationUser user = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            user.CookedRecipes.Remove(recipe);

            await data.SaveChangesAsync();
        }
    }
}
