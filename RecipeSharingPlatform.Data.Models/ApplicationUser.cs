

namespace RecipesSharingPlatform.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            Recipes = new HashSet<Recipe>();
            Comments = new HashSet<Comment>();
        }

        public virtual ICollection<Recipe> Recipes { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; } = null!;
    }
}
