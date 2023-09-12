using RecipeSharingPlatform.Web.ViewModels.Comment;
using RecipesSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Services.Data.Interfaces
{
    public interface ICommentService
    {
        Task AddComment(CommentFormModel commentFormModel, string userId);

        Task<ICollection<Comment>> GetComments(string recipeId);

        Task<bool> ExistsById(string commentId);

        Task<Comment> GetCommentByIdAsync(string commentId);

        Task<bool> IsCommentYours(string commentId, string userId);

        Task DeleteCommentByIdAsync(string commentId);

        Task<CommentFormModel> GetCommentAsFormModelAsync(string commentId);

        Task UpdateData(CommentFormModel commentFormModel);

 
    }
}
