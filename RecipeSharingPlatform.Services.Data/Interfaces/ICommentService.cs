using RecipeSharingPlatform.Web.ViewModels.Comment;
using RecipesSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    public interface ICommentService
    {
        Task AddComment(CommentFormModel commentFormModel, string userId);

        Task<ICollection<Comment>> GetComments(string recipeId);
    }
}
