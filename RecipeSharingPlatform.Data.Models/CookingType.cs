namespace RecipesSharingPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.CookingType;

    public class CookingType
    {
        public CookingType()
        {
            Recipes = new HashSet<Recipe>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTextLength, MinimumLength = MinTextLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Recipe> Recipes { get; set; }

        [StringLength(MaxDescriptionLength, MinimumLength = MinDescriptionLength)]
        public string? Description { get; set; }

       
        public string? ImageUrl { get; set; } 
    }
}
