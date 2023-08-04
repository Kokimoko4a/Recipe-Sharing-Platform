
namespace Recipe_Sharing_Platform_2.Controllers
{
    using RecipeSharingPlatform.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Services.Data.Models.Recipe;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    using static RecipeSharingPlatform.Common.NotificationMessagesConstants;
    using Microsoft.Extensions.Caching.Memory;
    using RecipeSharingPlatform.Web.ViewModels.User;
    using static RecipeSharingPlatform.Common.GeneralApplicationConstants;
    using static RecipeSharingPlatform.Common.EntityValidationConstants;

    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;
        private readonly ICategoryService categoryService;
        private readonly IDifficultyTypesService difficultyTypeService;
        private readonly ICookingTypeService cookingTypeService;
        private readonly ICommentService commentService;
        private readonly IUserService userService;

        public RecipeController(IRecipeService recipeService,
            ICategoryService categoryService,
            IDifficultyTypesService difficultyTypeService,
            ICookingTypeService cookingTypeService,
            ICommentService commentService,
            IUserService userService)
        {
            this.recipeService = recipeService;
            this.difficultyTypeService = difficultyTypeService;
            this.cookingTypeService = cookingTypeService;
            this.categoryService = categoryService;
            this.commentService = commentService;
            this.userService = userService;
        }

        [AllowAnonymous]
        [HttpGet]
        [ResponseCache(Duration = 30)]
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


            if (!User.Identity.IsAuthenticated)
            {

                if (await recipeService.GetRecipeByIdAsync(id, string.Empty) == null)
                {

                    TempData[WarningMessage] = "No such a recipe!";
                }

                try
                {


                    var comments = await commentService.GetComments(id);

                    var recipe = await recipeService.GetRecipeByIdAsync(id, string.Empty);



                    recipe.Comments = comments;

                    return View(recipe);

                }
                catch (Exception)
                {
                    return RedirectToAction("All");
                }
            }

            try
            {
                if (await recipeService.GetRecipeByIdAsync(id, User.GetId()!.ToString()) == null)
                {

                    TempData[WarningMessage] = "No such a recipe!";
                }

                var comments = await commentService.GetComments(id);

                var recipe = await recipeService.GetRecipeByIdAsync(id, User.GetId()!.ToString());



                recipe.Comments = comments;



                recipe.GuestUser = await userService.GetUserWithCookedRecipes(User.GetId()!);

                recipe.GuestUser.FavouriteRecipes = await userService.GetFavouriteRecipesByUserIdAsRecipeFullModel(User?.GetId().ToString());

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


            if (!isRecipeYours && !User.IsAdmin())
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

            if (!isRecipeYours && !User.IsAdmin())
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


            if (!isRecipeYours && !User.IsAdmin())
            {
                TempData[WarningMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }

            return View(new RecipeDeleteViewModel() { RecipeId = id });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(RecipeDeleteViewModel recipeDeleteViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData[WarningMessage] = "Inserted email is invalid";

                return View(recipeDeleteViewModel);
            }

            bool recipeExists = await recipeService.ExistsByIdAsync(recipeDeleteViewModel.RecipeId);


            if (!recipeExists)
            {
                TempData[WarningMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }

            bool isRecipeYours = await recipeService.IsRecipeYours(User.GetId()!, recipeDeleteViewModel.RecipeId);


            if (!isRecipeYours && !User.IsAdmin())
            {
                TempData[WarningMessage] = "You are not the publisher of that recipe or there is no such a recipe.";
                return RedirectToAction("All");
            }


            if (User.Identity!.Name != recipeDeleteViewModel.Email)
            {
                TempData[WarningMessage] = "Entered email is invalid!";
                return View(recipeDeleteViewModel);
            }

            try
            {
                await recipeService.DeleteAsync(recipeDeleteViewModel.RecipeId);

                TempData[SuccessMessage] = "Successfuly deleted recipe";

                return RedirectToAction("All");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                return RedirectToAction("All");

            }

        }

        [HttpPost]
        public async Task<IActionResult> MarkCooked(string recipeId)
        {
            if (!await recipeService.ExistsByIdAsync(recipeId))
            {
                TempData[ErrorMessage] = "No such a recipe";
                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");

            }


            try
            {
                await recipeService.MarkAsCookedRecipe(recipeId);

                await userService.AddCookedRecipe(recipeId, User!.GetId()!.ToString());

                TempData[SuccessMessage] = "Successfully marked recipe as cooked";

                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");

            }


        }

        [HttpGet]
        public async Task<IActionResult> ViewCookedRecipes()
        {
            return View(await userService.GetCookedRecipesByUserId(User.GetId().ToString()));
        }

        [HttpPost]
        public async Task<IActionResult> MarkUncooked(string recipeId)
        {
            if (!await recipeService.ExistsByIdAsync(recipeId))
            {
                TempData[ErrorMessage] = "No such a recipe";
                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");

            }



            try
            {
                await recipeService.MarkAsUnCookedRecipe(recipeId);

                await userService.RemoveCookedRecipe(recipeId, User!.GetId().ToString());

                TempData[SuccessMessage] = "Successfully marked recipe as uncooked";

                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");
            }



        }

        [HttpPost]
        public async Task<IActionResult> MarkFavourite(string recipeId)
        {
            try
            {

                await userService.MarkRecipeAsFavouriteAsync(recipeId, User.GetId().ToString());

                TempData[SuccessMessage] = "Successfully marked as favourite";

                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");
            }
            catch (Exception)
            {

                TempData[ErrorMessage] = "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> MarkUnfavourite(string recipeId)
        {

            try
            {
                await userService.MarkRecipeAsUnfavouriteAsync(recipeId, User.GetId()!.ToString());

                TempData[SuccessMessage] = "Succesfully removed from favourite recipes";

                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");
            }
            catch (Exception)
            {

                TempData[ErrorMessage] = "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{recipeId}");

            }
        }

        [HttpGet]
        public async Task<IActionResult> ViewFavourites()
        {
            return View(await userService.GetFavouriteRecipesByUserId(User.GetId()!.ToString()));
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
