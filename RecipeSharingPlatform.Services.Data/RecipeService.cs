

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
    using RecipeSharingPlatform.Services.Data.Models.Recipe;
    using System.Security.Cryptography.X509Certificates;

    public class RecipeService : IRecipeService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public RecipeService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<IndexViewModel>> LastThreeRecipesAsync()
        {
            List<IndexViewModel> recipes = await data.Recipes.OrderByDescending(r => r.CreatedOn).Select(x => new IndexViewModel()
            {
                Id = x.Id,
                AuthorName = x.Author!.Email,
                ImageURL = x.ImageUrl,
                Title = x.Title,
                Category = x.Category.Name
            }).Take(3).ToListAsync();

            return recipes;
        }

        public async Task<IEnumerable<RecipeViewModel>> AllRecipesAsync()
        {
            List<RecipeViewModel> recipes = await data.Recipes.OrderByDescending(r => r.CreatedOn).Select(x => new RecipeViewModel()
            {
                Id = x.Id,
               AuthorName= x.Author!.Email,
                ImageURL = x.ImageUrl,
                Title = x.Title,
                CountBeenCooked = x.CountBeenCooked
            }).ToListAsync();

            return recipes;
        }

        public async Task<RecipeBigViewModel> GetRecipeByIdAsync(string recipeId,string userId)
        {
            ApplicationUser user = null;

            if (userId != string.Empty)
            {
                user = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId);
            }

            

            RecipeBigViewModel recipeBigView = await data.Recipes.
                Include(r => r.Category)
                .Include(r => r.Author)
                .Include(r => r.CookingType)
                .Include(r => r.Difficulty)
                .Include(r => r.Ingredients)
                .Include(r => r.Comments)
                .Select(r => new RecipeBigViewModel() 
                {
                    Author = r.Author,
                    Description = r.Description,
                    Category = r.Category.Name,
                    Difficulty = r.Difficulty.Name,
                    Comments = r.Comments,
                    CookingTime = r.CookingTime,
                    CookingType = r.CookingType.Name,
                    CountBeenCooked = r.CountBeenCooked,
                    CountOfPortions = r.CountOfPortions,
                    CreatedOn = r.CreatedOn,
                    Id = r.Id,
                    ImageUrl = r.ImageUrl,
                    Ingredients = r.Ingredients,
                    PreparingTime = r.PreparingTime,
                    Title = r.Title,
                    GuestUser = user
                })
                .FirstOrDefaultAsync(r => r.Id.ToString() == recipeId)!;


            return recipeBigView;
        }

        public async Task CreateRecipeAsync(RecipeFormModel recipeFormModel, string userId)
        {
            List<string> ingredients = recipeFormModel.Ingredients.Split(Environment.NewLine).ToList();

            List<Ingredient> ingredientsForDb = new List<Ingredient>();

            foreach (var ingredientRow in ingredients)
            {

                string[] ingredientInfo = ingredientRow.Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray()!;

                // string[] ingredientQuanAndMT = ingredientInfo.ToString()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray()!;

                string[] ingredientQuanAndMT = ingredientInfo[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] typeMeasurementArray = ingredientQuanAndMT.Skip(1).ToArray();

                string typeMeasurement = string.Empty;

                foreach (var item in typeMeasurementArray)
                {
                    typeMeasurement += item;
                }

                Ingredient ingredientForDb = new Ingredient()
                {
                    Name = ingredientInfo[0],

                    TypeMeasurement = typeMeasurement
                };

                ingredientForDb.Quantity = decimal.Parse(ingredientQuanAndMT[0].Replace(',','.'));

                ingredientsForDb.Add(ingredientForDb);
            }

            Recipe recipe = new Recipe()
            {
                Description = recipeFormModel.Description,
                DifficultyId = recipeFormModel.DifficultyTypeId,
                AuthorId = Guid.Parse(userId),
                CategoryId = recipeFormModel.CategoryId,
                CookingTime = recipeFormModel.CookingTime,
                CookingTypeId = recipeFormModel.CookingTypeId,
                CountOfPortions = recipeFormModel.CountOfPortions,
                ImageUrl = recipeFormModel.ImageUrl!,
                PreparingTime = recipeFormModel.PreparingTime,
                Title = recipeFormModel.Title,
                Ingredients = ingredientsForDb
            };

            await data.Recipes.AddAsync(recipe);

            await data.SaveChangesAsync();
        }

        public async Task<AllRecipesFilteredAndPagedServiceModel> AllFilteredAsync(AllRecipesQueryModel queryModel)
        {
            IQueryable<Recipe> recipes = data.Recipes.AsQueryable();
            string wildcard = string.Empty;


            if (!string.IsNullOrWhiteSpace(queryModel.Category))
            {
                recipes = data.Recipes.Where(r => r.Category.Name == queryModel.Category);
            }

            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                wildcard = $"%{queryModel.SearchString}%";

                StringBuilder sb = new StringBuilder();

                IQueryable<Ingredient> ingredientsAll = data.Ingredients.AsQueryable();

                foreach (var ingredient in ingredientsAll)
                {
                    if (ingredient.Name.TrimEnd().TrimStart() == queryModel.SearchString.TrimStart().TrimEnd())
                    {
                        sb.AppendLine(ingredient.Name);
                    }

                   
                }

                if (!string.IsNullOrWhiteSpace(queryModel.Category))
                {
                    

                    //string additionalInfoToSearchIn = 

                    recipes = data.Recipes.Where(r => EF.Functions.Like(r.Title, wildcard) || EF.Functions.Like(r.Category.Name, wildcard) ||
                    EF.Functions.Like(r.CookingType.Name, wildcard) || EF.Functions.Like(r.Difficulty.Name, wildcard) || EF.Functions.Like(sb.ToString(), wildcard)).Where((r => r.Category.Name == queryModel.Category));
                }

                else
                {
                    recipes = data.Recipes.Where(r => EF.Functions.Like(r.Title, wildcard) || EF.Functions.Like(r.Category.Name, wildcard) ||
                   EF.Functions.Like(r.CookingType.Name, wildcard) || EF.Functions.Like(r.Difficulty.Name, wildcard) || EF.Functions.Like(sb.ToString(), wildcard));

                   
                }

            }

            if (!string.IsNullOrWhiteSpace(queryModel.CookingType))
            {
                if (!string.IsNullOrWhiteSpace(queryModel.SearchString) && !string.IsNullOrWhiteSpace(queryModel.Category))
                {
                    recipes = data.Recipes.Where(r => r.CookingType.Name == queryModel.CookingType)
                    .Where(r => r.Category.Name == queryModel.Category)
                   .Where(r => EF.Functions.Like(r.Title, wildcard) || EF.Functions.Like(r.Category.Name, wildcard) ||
                EF.Functions.Like(r.CookingType.Name, wildcard) || EF.Functions.Like(r.Difficulty.Name, wildcard));
                }

                else if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
                {
                    recipes = data.Recipes.Where(r => r.CookingType.Name == queryModel.CookingType)
                        .Where(r => EF.Functions.Like(r.Title, wildcard)
                        || EF.Functions.Like(r.Category.Name, wildcard)
                        || EF.Functions.Like(r.CookingType.Name, wildcard)
                        || EF.Functions.Like(r.Difficulty.Name, wildcard));
                }

                else if (!string.IsNullOrWhiteSpace(queryModel.Category))
                {
                    recipes = data.Recipes.Where(r => r.CookingType.Name == queryModel.CookingType)
                   .Where(r => r.Category.Name == queryModel.Category);
                }

                else
                {
                    recipes = data.Recipes.Where(r => r.CookingType.Name == queryModel.CookingType);
                }
            }

            if (!string.IsNullOrWhiteSpace(queryModel.DifficultyType))
            {
                if (!string.IsNullOrWhiteSpace(queryModel.Category) && !string.IsNullOrWhiteSpace(queryModel.SearchString)
                    && !string.IsNullOrWhiteSpace(queryModel.CookingType))
                {
                    recipes = data.Recipes.Where(r => r.Difficulty.Name == queryModel.DifficultyType)
                        .Where(r => r.Category.Name == queryModel.Category)
                        .Where(r => EF.Functions.Like(r.Title, wildcard)
                        || EF.Functions.Like(r.Category.Name, wildcard)
                        || EF.Functions.Like(r.CookingType.Name, wildcard)
                        || EF.Functions.Like(r.Difficulty.Name, wildcard))
                        .Where(r => r.CookingType.Name == queryModel.CookingType);
                }

                else if (!string.IsNullOrWhiteSpace(queryModel.SearchString)
                    && !string.IsNullOrWhiteSpace(queryModel.CookingType))
                {
                    recipes = data.Recipes.Where(r => r.Difficulty.Name == queryModel.DifficultyType)
                        .Where(r => EF.Functions.Like(r.Title, wildcard)
                        || EF.Functions.Like(r.Category.Name, wildcard)
                        || EF.Functions.Like(r.CookingType.Name, wildcard)
                        || EF.Functions.Like(r.Difficulty.Name, wildcard))
                        .Where(r => r.CookingType.Name == queryModel.CookingType);
                }

                else if (!string.IsNullOrWhiteSpace(queryModel.SearchString)
                    && !string.IsNullOrWhiteSpace(queryModel.Category))
                {
                    recipes = data.Recipes.Where(r => r.Difficulty.Name == queryModel.DifficultyType)
                        .Where(r => EF.Functions.Like(r.Title, wildcard)
                        || EF.Functions.Like(r.Category.Name, wildcard)
                        || EF.Functions.Like(r.CookingType.Name, wildcard)
                        || EF.Functions.Like(r.Difficulty.Name, wildcard))
                        .Where(r => r.Category.Name == queryModel.Category);

                }

                else if (!string.IsNullOrWhiteSpace(queryModel.Category) && !string.IsNullOrWhiteSpace(queryModel.CookingType))
                {
                    recipes = data.Recipes.Where(r => r.Difficulty.Name == queryModel.DifficultyType)
                        .Where(r => r.CookingType.Name == queryModel.CookingType)
                        .Where(r => r.Category.Name == queryModel.Category);
                }

                else if (!string.IsNullOrWhiteSpace(queryModel.Category))
                {
                    recipes = data.Recipes.Where(r => r.Difficulty.Name == queryModel.DifficultyType)
                        .Where(r => r.Category.Name == queryModel.Category);
                }

                else if (!string.IsNullOrWhiteSpace(queryModel.CookingType))
                {
                    recipes = data.Recipes.Where(r => r.Difficulty.Name == queryModel.DifficultyType)
                        .Where(r => r.CookingType.Name == queryModel.CookingType);
                }

                else if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
                {
                    recipes = data.Recipes.Where(r => r.Difficulty.Name == queryModel.DifficultyType)
                       .Where(r => EF.Functions.Like(r.Title, wildcard)
                       || EF.Functions.Like(r.Category.Name, wildcard)
                       || EF.Functions.Like(r.CookingType.Name, wildcard)
                       || EF.Functions.Like(r.Difficulty.Name, wildcard));
                }

                else
                {
                    recipes = data.Recipes.Where(r => r.Difficulty.Name == queryModel.DifficultyType);
                }
            }

            IEnumerable<RecipeViewModel> recipeViews = await recipes.Skip((queryModel.CurrentPage - 1) * queryModel.RecipesByPage)
                .Take(queryModel.RecipesByPage)
                .Select(r => new RecipeViewModel()
                {
                    Id = r.Id,
                    AuthorName = r.Author!.Email,
                    ImageURL = r.ImageUrl,
                    Title = r.Title,
                    CountBeenCooked = r.CountBeenCooked
                }).ToArrayAsync();

            int totalRecipes = queryModel.TotalRecipes;

            return new AllRecipesFilteredAndPagedServiceModel()
            {
                Recipes = recipeViews,
                TotalRecipesCount = totalRecipes
            };
        }

        public async Task<IEnumerable<RecipeViewModel>> GetAllRecipesByUserId(string userId)
        {
            ICollection<RecipeViewModel> recipes = await data.Recipes.Where(r => r.AuthorId.ToString() == userId)
                .Select(x => new RecipeViewModel()
                {
                    Id = x.Id,
                    AuthorName = x.Author!.Email,
                    ImageURL = x.ImageUrl,
                    Title = x.Title,
                    CountBeenCooked = x.CountBeenCooked,
                }).ToListAsync();

            return recipes;
        }

        public async Task<bool> IsRecipeYours(string userId, string recipeId)
        {
            Recipe recipe = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == recipeId)!;

            return recipe!.AuthorId.ToString() == userId;
        }

        public async Task<RecipeFormModel> GetRecipeAsFormModel(string recipeId)
        {
            StringBuilder sb = new StringBuilder();

            RecipeFormModel recipeFormModel = await data.Recipes.Select(r => new RecipeFormModel()
            {
                Id = r.Id.ToString(),
                CookingTime = r.CookingTime,
                CountOfPortions = r.CountOfPortions,
                ImageUrl = r.ImageUrl,
                Description = r.Description,
                Title = r.Title,
                CategoryId = r.CategoryId,
                DifficultyTypeId = r.DifficultyId,
                CookingTypeId = r.CookingTypeId,
                PreparingTime= r.PreparingTime
            }).FirstOrDefaultAsync(r => r.Id == recipeId);


            ICollection<Ingredient> ingredients = await data.Ingredients.Where(i => i.RecipeId.ToString() == recipeId).ToListAsync();

            foreach (var ingredient in ingredients)
            {
                sb.AppendLine($"{ingredient.Name} - {ingredient.Quantity} {ingredient.TypeMeasurement}");
            }

            recipeFormModel.Ingredients = sb.ToString().TrimEnd();    

            return recipeFormModel;
        }

        public async Task<bool> ExistsByIdAsync(string recipeId)
        {
            return await data.Recipes.AnyAsync(r => r.Id.ToString() == recipeId);
        }

        public async Task EditRecipeAsync(RecipeFormModel recipeFormModel)
        {
            Recipe recipe = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == recipeFormModel.Id);

            recipe.Title = recipeFormModel.Title;
            recipe.DifficultyId = recipeFormModel.DifficultyTypeId;
            recipe.CategoryId = recipeFormModel.CategoryId;
            recipe.Description = recipeFormModel.Description;
            recipe.CookingTime = recipeFormModel.CookingTime;
            recipe.CookingTypeId = recipeFormModel.CookingTypeId;
            recipe.PreparingTime = recipeFormModel.PreparingTime;
            recipe.ImageUrl = recipeFormModel.ImageUrl!;

            ICollection<Ingredient> ingredients = await data.Ingredients.Where(i => i.RecipeId.ToString() == recipeFormModel.Id).ToListAsync();

            data.Ingredients.RemoveRange(ingredients);

            recipe.Ingredients = CreateIngredients(recipeFormModel);

            await data.SaveChangesAsync();

        }

        public ICollection<Ingredient> CreateIngredients(RecipeFormModel recipeFormModel)
        {
            ICollection<string> ingredients = recipeFormModel.Ingredients.Split(Environment.NewLine).ToList();

            ICollection<Ingredient> ingredientsForDb = new List<Ingredient>();

            foreach (var ingredientRow in ingredients)
            {

                string[] ingredientInfo = ingredientRow.Split('-', StringSplitOptions.RemoveEmptyEntries).ToArray()!;

                // string[] ingredientQuanAndMT = ingredientInfo.ToString()!.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray()!;

                string[] ingredientQuanAndMT = ingredientInfo[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Ingredient ingredientForDb = new Ingredient()
                {
                    Name = ingredientInfo[0],

                    TypeMeasurement = ingredientQuanAndMT[1]
                };

                ingredientForDb.Quantity = decimal.Parse(ingredientQuanAndMT[0]);

                ingredientsForDb.Add(ingredientForDb);
            }

            return ingredientsForDb;
        }

        public async Task DeleteAsync(RecipeDeleteViewModel recipeDeleteViewModel)
        {
            Recipe recipe = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == recipeDeleteViewModel.RecipeId);

            data.Recipes.Remove(recipe!);

            ICollection<Ingredient> ingredients = await data.Ingredients.Where(i => i.RecipeId.ToString() == recipeDeleteViewModel.RecipeId).ToListAsync();

            data.Ingredients.RemoveRange(ingredients);

            await data.SaveChangesAsync();
        }

        public async Task MarkAsCookedRecipe(string id)
        {
            Recipe recipe = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == id);

            recipe.CountBeenCooked++;

            await data.SaveChangesAsync();
        }

        public async Task MarkAsUnCookedRecipe(string recipeId)
        {
            Recipe recipe = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == recipeId);

            recipe.CountBeenCooked--;

            await data.SaveChangesAsync();
        }
    }
}