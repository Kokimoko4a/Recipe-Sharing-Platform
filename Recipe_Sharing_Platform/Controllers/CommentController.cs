namespace Recipe_Sharing_Platform.Web.Controllers
{
    using RecipeSharingPlatform.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Comment;
    using static RecipeSharingPlatform.Common.NotificationMessagesConstants;

    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IRecipeService recipeService;

        public CommentController(ICommentService commentService, IRecipeService recipeService)
        {
            this.commentService = commentService;
            this.recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> AddComment(string id)
        {
            bool exists = await recipeService.ExistsByIdAsync(id);

            if (!exists) 
            {
                TempData[WarningMessage] = "No such a recipe!";
                return RedirectToAction("All", "Recipe");
            }

            return View(new CommentFormModel() { RecipeId = id});
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentFormModel commentFormModel)
        {
            if (!ModelState.IsValid)
            {
                return View(commentFormModel);
            }

            bool exists = await recipeService.ExistsByIdAsync(commentFormModel.RecipeId);

            if (!exists)
            {
                TempData[WarningMessage] = "No such a recipe!";
                return RedirectToAction("All", "Recipe");
            }

            try
            {
                await commentService.AddComment(commentFormModel, User.GetId()!);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred while trying to post your comment! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to post your comment! Please try again later or contact administrator.");
            }

            return Redirect($"https://localhost:7024/Recipe/ViewRecipe/{commentFormModel.RecipeId}");
        }

    }
}
