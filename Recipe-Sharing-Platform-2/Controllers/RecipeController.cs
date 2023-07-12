
namespace Recipe_Sharing_Platform_2.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RecipeSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;

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
    }
}
