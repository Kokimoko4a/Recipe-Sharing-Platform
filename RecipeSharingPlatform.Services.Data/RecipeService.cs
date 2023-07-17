

namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipesSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Home;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                Title = x.Title,
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
                Title = x.Title,
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

        public async Task CreateRecipeAsync(RecipeFormModel recipeFormModel, string userId)
        {
            List<string> ingredients = recipeFormModel.Ingredients.Split(Environment.NewLine).ToList();

            List<Ingredient> ingredientsForDb = new List<Ingredient>();

            foreach (var ingredientRow in ingredients)
            {

                string[] ingredientInfo = ingredientRow.Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray()!;

                // string[] ingredientQuanAndMT = ingredientInfo.ToString()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray()!;

                string[] ingredientQuanAndMT = ingredientInfo[1].Split(' ',StringSplitOptions.RemoveEmptyEntries);

                Ingredient ingredientForDb = new Ingredient()
                { 
                    Name= ingredientInfo[0],
                   
                    TypeMeasurement = ingredientQuanAndMT[1]
                };

                ingredientForDb.Quantity = decimal.Parse(ingredientQuanAndMT[0]);

                ingredientsForDb.Add(ingredientForDb);   
            }

            Recipe recipe  = new Recipe()
            { 
                Description= recipeFormModel.Description,
                DifficultyId = recipeFormModel.DifficultyTypeId,
                AuthorId = Guid.Parse(userId),
                CategoryId = recipeFormModel.CategoryId,
                CookingTime = recipeFormModel.CookingTime,
                CookingTypeId = recipeFormModel.CookingTypeId,
                CountOfPortions = recipeFormModel.CountOfPortions,
                ImageUrl = recipeFormModel.ImageUrl!,
                PreparingTime = recipeFormModel.PreparingTime,
                Title= recipeFormModel.Title,
                Ingredients= ingredientsForDb
            };

            await data.Recipes.AddAsync(recipe);

            await data.SaveChangesAsync();
        }
    }
}