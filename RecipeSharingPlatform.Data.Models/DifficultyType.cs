


namespace RecipeSharingPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.DifficultyType;

    public class DifficultyType
    {
        public DifficultyType()
        {
            Recipes = new HashSet<Recipe>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxTextLength, MinimumLength = MinTextLength)]
        public string Name { get; set; } = null!;

        [Required]
        public virtual ICollection<Recipe> Recipes { get; set; } = null!;
    }
}
