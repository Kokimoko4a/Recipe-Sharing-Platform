namespace RecipeSharingPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Category;

    public class Category
    {
        public Category()
        {
            Recipes = new HashSet<Recipe>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameMaxLength, MinimumLength = CategoryNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}