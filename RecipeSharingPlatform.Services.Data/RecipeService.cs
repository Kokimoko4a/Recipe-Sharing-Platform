using Microsoft.EntityFrameworkCore;
using Recipe_Sharing_Platform_2.Data;
using RecipeSharingPlatform.Services.Data.Interfaces;
using RecipeSharingPlatform.Web.ViewModels.Home;
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

        public async Task<IEnumerable<IndexViewModel>> LastSixRecipes()
        {
            List<IndexViewModel> recipes = await data.Recipes.OrderByDescending(r => r.CreatedOn).Select(x => new IndexViewModel()
            {
                AuthorName = x.Author!.Email,
                ImageURL = x.ImageUrl,
                Title = x.Name
            }).Take(6).ToListAsync();

            return recipes;
        }
    }
}
