using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipesSharingPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Ingredient;

    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        
        [Range((double)MinNeededQuantity, (double)MaxNeededQuantity)]
        public decimal? Quantity { get; set; }


        [StringLength(MaxLengthOfTypeMeasurement, MinimumLength = MinLengthOfTypeMeasurement)]
        public string? TypeMeasurement { get; set; }

        [Required]
        public Recipe Recipe { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }
    }
}
