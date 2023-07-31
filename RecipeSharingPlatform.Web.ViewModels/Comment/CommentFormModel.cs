namespace RecipeSharingPlatform.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Comment;

    public class CommentFormModel
    {
        [StringLength(MaxTextLength, MinimumLength = MinTextLength)]
        public string Content { get; set; } = null!;

        public string RecipeId { get; set; } = null!;

        public string? CommentId { get; set; } 
    }
}
