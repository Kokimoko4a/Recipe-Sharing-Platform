
namespace Recipe_Sharing_Platform_2.Controllers
{
    using HouseRentingSystem.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    using RecipesSharingPlatform.Data.Models;

    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly ICategoryService categoryService;
        private readonly IDifficultyTypesService difficultyTypeService;
        private readonly ICookingTypeService cookingTypeService;

        public RecipeController(IRecipeService recipeService, ICategoryService categoryService, IDifficultyTypesService difficultyTypeService, ICookingTypeService cookingTypeService)
        {
            this.recipeService = recipeService;
            this.difficultyTypeService = difficultyTypeService;
            this.cookingTypeService = cookingTypeService;
            this.categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View(await recipeService.AllRecipesAsync());
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ViewRecipe(Guid id)
        {

            if (await recipeService.GetRecipeByIdAsync(id) == null)
            {
                TempData["ErrorMessage"] = "Bazinga!! No such a recipe";

                return RedirectToAction("All");
            }

            try
            {
                Recipe recipe = await recipeService.GetRecipeByIdAsync(id);

                return View(recipe);

            }
            catch (Exception)
            {
                return RedirectToAction("All");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            RecipeFormModel recipeFormModel = new RecipeFormModel()
            {
                Categories = await categoryService.GetAllCategoriesAsync(),
                DifficultyTypes = await difficultyTypeService.GetAllDifficultyTypesAsync(),
                CookingTypes = await cookingTypeService.GetAllCookingTypesAsync()
            };

            return View(recipeFormModel);

        }

        [HttpPost]
        public async Task<IActionResult> Add(RecipeFormModel recipeFormModel)
        {
            bool cookingTypeExists = await cookingTypeService.ExistsById(recipeFormModel.CookingTypeId);
            bool difficultyTypeExists = await difficultyTypeService.ExistsById(recipeFormModel.DifficultyTypeId);
            bool categoryTypeExists = await categoryService.ExistsById(recipeFormModel.CategoryId);

            if (!cookingTypeExists)
            {
                ModelState.AddModelError(nameof(recipeFormModel.CookingTypeId), "Selected cooking type does not exist");
            }

            if (!difficultyTypeExists)
            {
                ModelState.AddModelError(nameof(recipeFormModel.DifficultyTypeId), "Selected difficulty does not exist");
            }

            if (!categoryTypeExists)
            {
                ModelState.AddModelError(nameof(recipeFormModel.CategoryId), "Selected categoty does not exist");
            }

            if (!ModelState.IsValid)
            {
                recipeFormModel.Categories = await categoryService.GetAllCategoriesAsync();
                recipeFormModel.DifficultyTypes = await difficultyTypeService.GetAllDifficultyTypesAsync();
                recipeFormModel.CookingTypes = await cookingTypeService.GetAllCookingTypesAsync();

                return View(recipeFormModel);
            }



           // try
           // {
                await recipeService.CreateRecipeAsync(recipeFormModel, User.GetId()!);

                return RedirectToAction("All");
           // }
           /* catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                recipeFormModel.Categories = await categoryService.GetAllCategoriesAsync();
                recipeFormModel.DifficultyTypes = await difficultyTypeService.GetAllDifficultyTypesAsync();
                recipeFormModel.CookingTypes = await cookingTypeService.GetAllCookingTypesAsync();

                return View(recipeFormModel);
            }*/
        }
    }
}