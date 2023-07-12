using Microsoft.EntityFrameworkCore;
using Recipe_Sharing_Platform_2.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.Services.Data.Interfaces;
using RecipeSharingPlatform.Web.ViewModels.Home;
using RecipeSharingPlatform.Web.ViewModels.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSharingPlatform.Services.Data
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public RecipeService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<IndexViewModel>> LastSixRecipesAsync()
        {
            List<IndexViewModel> recipes = await data.Recipes.OrderByDescending(r => r.CreatedOn).Select(x => new IndexViewModel()
            {
                Id = x.Id,
                AuthorName = x.Author!.Email,
                ImageURL = x.ImageUrl,
                Title = x.Name,
                Category = x.Category.Name
            }).Take(6).ToListAsync();

            return recipes;
        }

        public async Task<IEnumerable<RecipeViewModel>> AllRecipesAsync()
        {
            List<RecipeViewModel> recipes = await data.Recipes.OrderByDescending(r => r.CreatedOn).Select(x => new RecipeViewModel()
            {
                Id = x.Id,
                AuthorName = x.Author!.Email,
                ImageURL = x.ImageUrl,
                Title = x.Name,
                Category = x.Category.Name
            }).ToListAsync();

            return recipes;
        }

        public async Task<Recipe> GetRecipeByIdAsync(Guid id)
        {
            Recipe recipe = await data.Recipes.
                Include(r => r.Category)
                .Include(r => r.Author)
                .Include(r => r.CookingType)
                .Include(r => r.Difficulty)
                .Include(r => r.Ingredients)
                .FirstOrDefaultAsync(r => r.Id == id)!;


            return recipe;
        }
    }
}
