

namespace RecipesSharingPlatform.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            Recipes = new HashSet<Recipe>();
            Comments = new HashSet<Comment>();
            CookedRecipes = new HashSet<Recipe>();
        }

        public virtual ICollection<Recipe> Recipes { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; } = null!;

        [Required]
        [StringLength(MaxFirstNameLength, MinimumLength = MinFirstNameLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(MaxLastNameLength, MinimumLength = MinLastNameLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Recipe> CookedRecipes { get; set; } = null!;
    }
}
