namespace RecipeSharingPlatform.Web.ViewModels.Recipe
{
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.User;

    public class RecipeDeleteViewModel
    {
        [Required]
        [StringLength(MaxEmailLength,MinimumLength = MinEmailLength)]
        public string Email { get; set; } = null!;

        [Required]
        public string RecipeId { get; set; } = null!;

    }
}
