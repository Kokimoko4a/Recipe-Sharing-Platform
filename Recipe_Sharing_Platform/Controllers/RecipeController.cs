
namespace Recipe_Sharing_Platform_2.Controllers
{
    using RecipeSharingPlatform.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Services.Data.Models.Recipe;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    // using RecipesSharingPlatform.Data.Models;
    using static RecipeSharingPlatform.Common.NotificationMessagesConstants;

    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly ICategoryService categoryService;
        private readonly IDifficultyTypesService difficultyTypeService;
        private readonly ICookingTypeService cookingTypeService;
        private readonly ICommentService commentService;

        public RecipeController(IRecipeService recipeService, ICategoryService categoryService, IDifficultyTypesService difficultyTypeService, ICookingTypeService cookingTypeService, ICommentService commentService)
        {
            this.recipeService = recipeService;
            this.difficultyTypeService = difficultyTypeService;
            this.cookingTypeService = cookingTypeService;
            this.categoryService = categoryService;
            this.commentService = commentService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllRecipesQueryModel queryModel)
        {
            AllRecipesFilteredAndPagedServiceModel serviceRecipes = await recipeService.AllFilteredAsync(queryModel);

            queryModel.Recipes = serviceRecipes.Recipes;
            queryModel.TotalRecipes = serviceRecipes.TotalRecipesCount;
            queryModel.Categories = await categoryService.AllCategoryNamesAsync();
            queryModel.DifficultyTypes = await difficultyTypeService.AllDifficultyTypeNamesAsync();
            queryModel.CookingTypes = await cookingTypeService.AllCookingTypeNamesAsync();

            return View(queryModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ViewRecipe(string id)
        {

            if (await recipeService.GetRecipeByIdAsync(id) == null)
            {

                TempData[WarningMessage] = "No such a recipe!";
            }

            try
            {
               

                var comments = await commentService.GetComments(id);

                var recipe = await recipeService.GetRecipeByIdAsync(id);

                recipe.Comments = comments;


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
                TempData[WarningMessage] = "Selected cooking type does not exist";
                ModelState.AddModelError(nameof(recipeFormModel.CookingTypeId), "Selected cooking type does not exist");
            }

            if (!difficultyTypeExists)
            {
                TempData[WarningMessage] = "Selected difficulty does not exist";
                ModelState.AddModelError(nameof(recipeFormModel.DifficultyTypeId), "Selected difficulty does not exist");
            }

            if (!categoryTypeExists)
            {
                TempData[WarningMessage] = "Selected categoty does not exist";
                ModelState.AddModelError(nameof(recipeFormModel.CategoryId), "Selected categoty does not exist");
            }

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessage] = "Inserted data is invalid";
                recipeFormModel.Categories = await categoryService.GetAllCategoriesAsync();
                recipeFormModel.DifficultyTypes = await difficultyTypeService.GetAllDifficultyTypesAsync();
                recipeFormModel.CookingTypes = await cookingTypeService.GetAllCookingTypesAsync();

                return View(recipeFormModel);
            }

            try
            {
                await recipeService.CreateRecipeAsync(recipeFormModel, User.GetId()!);

                TempData[SuccessMessage] = "Succesfuly created recipe.";

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                recipeFormModel = await LoadData(recipeFormModel);

                return View(recipeFormModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {


            return View(await recipeService.GetAllRecipesByUserId(User.GetId()!));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool recipeExists = await recipeService.ExistsByIdAsync(id);

            if (!recipeExists)
            {
                TempData[ErrorMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }

            bool isRecipeYours = await recipeService.IsRecipeYours(User.GetId()!, id);


            if (!isRecipeYours)
            {
                TempData[ErrorMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }

            RecipeFormModel recipeFormModel = await recipeService.GetRecipeAsFormModel(id);

            recipeFormModel = await LoadData(recipeFormModel);

            return View(recipeFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeFormModel recipeFormModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage] = "Inserted data is invalid";

                recipeFormModel = await LoadData(recipeFormModel);
                return View(recipeFormModel);
            }

            bool recipeExists = await recipeService.ExistsByIdAsync(recipeFormModel.Id);

            if (!recipeExists)
            {
                TempData[ErrorMessage] = "You are not the publisher of that recipe or it does not exist";

                recipeFormModel = await LoadData(recipeFormModel);
                return View(recipeFormModel);
            }

            bool isRecipeYours = await recipeService.IsRecipeYours(User.GetId()!, recipeFormModel.Id);

            if (!isRecipeYours)
            {
                TempData[ErrorMessage] = "You are not the publisher of that recipe or it does not exist";

                recipeFormModel = await LoadData(recipeFormModel);
                return View(recipeFormModel);
            }


            try
            {
                await recipeService.EditRecipeAsync(recipeFormModel);

                TempData[SuccessMessage] = "Successfuly edited recipe";

                return RedirectToAction("All");

            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                recipeFormModel = await LoadData(recipeFormModel);

                return View(recipeFormModel);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool recipeExists = await recipeService.ExistsByIdAsync(id);

            if (!recipeExists)
            {
                TempData[WarningMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }

            bool isRecipeYours = await recipeService.IsRecipeYours(User.GetId()!, id);


            if (!isRecipeYours)
            {
                TempData[WarningMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }

            return View(new RecipeDeleteViewModel() {RecipeId = id });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(RecipeDeleteViewModel recipeDeleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage] = "Inserted password is invalid";

                return View(recipeDeleteViewModel);
            }

            bool recipeExists = await recipeService.ExistsByIdAsync(recipeDeleteViewModel.RecipeId);

            if (!recipeExists)
            {
                TempData[WarningMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }

            bool isRecipeYours = await recipeService.IsRecipeYours(User.GetId()!, recipeDeleteViewModel.RecipeId);


            if (!isRecipeYours)
            {
                TempData[WarningMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }


            if (User.Identity!.Name != recipeDeleteViewModel.Email)
            {
                TempData[WarningMessage] = "Entered email is invalid!";
                return View(recipeDeleteViewModel);
            }

                 
           await recipeService.DeleteByIdAsync(recipeDeleteViewModel);

            TempData[SuccessMessage] = "Successfuly deleted recipe";

            return RedirectToAction("All");
        }


        private async Task<RecipeFormModel> LoadData(RecipeFormModel recipeFormModel)
        {
            recipeFormModel.Categories = await categoryService.GetAllCategoriesAsync();
            recipeFormModel.DifficultyTypes = await difficultyTypeService.GetAllDifficultyTypesAsync();
            recipeFormModel.CookingTypes = await cookingTypeService.GetAllCookingTypesAsync();

            return recipeFormModel;
        }
    }
}
