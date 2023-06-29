namespace RecipeSharingPlatform.Data.Models
{
    using System;
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

        [Required]
        [Range(MinNeededQuantity, MaxNeededQuantity)]
        public int Quantity { get; set; }

        [Required]
        [StringLength(MaxLengthOfTypeMeasurement, MinimumLength = MinLengthOfTypeMeasurement)]
        public string TypeMeasurement { get; set; } = null!;

        [Required]
        public Recipe Recipe { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }
    }
}
