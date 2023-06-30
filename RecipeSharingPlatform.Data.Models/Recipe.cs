

namespace RecipeSharingPlatform.Data.Models
{
   // using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Recipe;

    public class Recipe
    {
        public Recipe()
        {
            Id = Guid.NewGuid();

            Ingredients = new HashSet<Ingredient>();

            Comments = new HashSet<Comment>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(MinTimeForCooking, MaxTimeForCooking)]
        public int CookingTime { get; set; }

        [Required]
        [Range(MinCountOfPortions,MaxCountOfPortions)]
        public int CountOfPortions { get; set; }

        [Required]
        [Range(MinTimeForPreparing,MaxTimeForPreparing)]
        public int PreparingTime { get; set; }

        public int TotalTime { get => PreparingTime + CookingTime; }

        [Required]
        public virtual Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public virtual ICollection<Ingredient> Ingredients { get; set; } = null!;

        [Required]
        public string CookingType { get; set; } = null!;

        [Required]
        public string RecipeType { get; set; } = null!;

        [Required]
        public string Difficulty { get; set; } = null!;

        [Required]
        [MaxLength(MaxImageUrlLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public virtual ICollection<Comment> Comments { get; set; } = null!;

        [Required]
        public virtual ApplicationUser? Author { get; set; } 

        [Required]
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
    }
}
