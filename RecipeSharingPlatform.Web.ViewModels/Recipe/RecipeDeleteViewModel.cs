


namespace RecipeSharingPlatform.Web.ViewModels.Recipe
{
    using System.ComponentModel.DataAnnotations;

    public class RecipeDeleteViewModel
    {
        [Required]
        [StringLength(100,MinimumLength = 6)]
        public string Email { get; set; } = null!;

        [Required]
        public string RecipeId { get; set; } = null!;

    }
}
