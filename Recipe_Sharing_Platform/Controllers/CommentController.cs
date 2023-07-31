namespace Recipe_Sharing_Platform.Web.Controllers
{
    using RecipeSharingPlatform.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Comment;
    using static RecipeSharingPlatform.Common.NotificationMessagesConstants;

    [Authorize]
    [Route("Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly IRecipeService recipeService;

        public CommentController(ICommentService commentService,
            IRecipeService recipeService)
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

            return View("AddComment",new CommentFormModel() { RecipeId = id});
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

        [Route("Comment/Delete/{id}")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (!await commentService.ExistsById(id))
            {
                TempData[ErrorMessage] = "Comment does not exist";
                return Redirect($"https://localhost:7024/Recipe/All/");
            }

            if (!await commentService.IsCommentYours(id, User?.GetId()!.ToString()))
            {
                TempData[WarningMessage] = "Comment is not yours! You are miserable!";
                return Redirect($"https://localhost:7024/Recipe/All/");
            }



            return View("Delete",new CommentDeleteViewModel() {CommentId = id});
        }

        [Route("Comment/Delete/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(CommentDeleteViewModel commentDeleteViewModel)
        {
            if (!await commentService.ExistsById(commentDeleteViewModel.CommentId))
            {
                TempData[ErrorMessage] = "Comment does not exist";
            }

            if (! await commentService.IsCommentYours(commentDeleteViewModel.CommentId, User?.GetId()!.ToString()))
            {
                TempData[WarningMessage] = "Comment is not yours! You are miserable!";
                return Redirect($"https://localhost:7024/Recipe/All/");
            }

            if (commentDeleteViewModel.Email != User.Identity.Name)
            {
                TempData[ErrorMessage] = "Entered email is not valid";
                return View(commentDeleteViewModel);
                return Redirect($"https://localhost:7024/Recipe/All");
            }

            if (!ModelState.IsValid)
            {
                return View(commentDeleteViewModel);
            }

            await commentService.DeleteCommentByIdAsync(commentDeleteViewModel.CommentId);
            TempData[SuccessMessage] = "Successfully deleted your comment";
            return Redirect($"https://localhost:7024/Recipe/All");

        }




    }
}
