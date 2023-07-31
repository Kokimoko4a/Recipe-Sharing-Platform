

namespace RecipeSharingPlatform.Web.ViewModels.Comment
{
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.User;

    public class CommentDeleteViewModel
    {
        [StringLength(MaxEmailLength, MinimumLength = MinEmailLength)]
        public string Email { get; set; } = null!;

        public string? CommentId { get; set; } 
        public string? RecipeId { get; set; } 
    }
}
