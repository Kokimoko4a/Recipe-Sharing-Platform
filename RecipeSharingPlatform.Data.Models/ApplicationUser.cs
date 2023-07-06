

using Microsoft.AspNetCore.Identity;

namespace RecipeSharingPlatform.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            Recipes = new HashSet<Recipe>();
        }

        public virtual ICollection<Recipe> Recipes { get; set; } = null!;
    }
}
