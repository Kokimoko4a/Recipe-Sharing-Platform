
using RecipesSharingPlatform.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharingPlatform.Web.ViewModels.Recipe
{
    public class RecipeBigViewModel
    {
        public RecipeBigViewModel()
        {
            Ingredients = new HashSet<Ingredient>();
            Comments = new HashSet<RecipesSharingPlatform.Data.Models.Comment>();
        }

        public ApplicationUser GuestUser { get; set; } = null!;

      
        public Guid Id { get; set; }


        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int CookingTime { get; set; }


        public int CountOfPortions { get; set; }

        public int PreparingTime { get; set; }

        public int TotalTime { get => PreparingTime + CookingTime; protected set { } }


        public string Category { get; set; } = null!;


        public virtual ICollection<Ingredient> Ingredients { get; set; } = null!;


        public string CookingType { get; set; } = null!;


        public string Difficulty { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;


      
        public virtual ApplicationUser? Author { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public virtual ICollection<RecipesSharingPlatform.Data.Models.Comment> Comments { get; set; } = null!;

        public int CountBeenCooked { get; set; }
    }
}
