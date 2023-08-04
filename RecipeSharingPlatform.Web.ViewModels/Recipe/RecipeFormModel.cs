
namespace RecipeSharingPlatform.Web.ViewModels.Recipe
{
    using RecipeSharingPlatform.Web.ViewModels.Category;
    using RecipeSharingPlatform.Web.ViewModels.CookingType;
    using RecipeSharingPlatform.Web.ViewModels.DifficultyType;
    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Recipe;
    public class RecipeFormModel
    {
        public RecipeFormModel()
        {
            Categories = new HashSet<RecipeCategorySelectFormModel>();

            CookingTypes = new HashSet<RecipeCookingTypeSelectFormModel>();

            DifficultyTypes = new HashSet<RecipeDifficultyTypeSelectFormModel>();
        }

        public string? Id { get; set; }

        [Required]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;


        [Range(MinTimeForCooking, MaxTimeForCooking)]
        [Display(Name = "Cooking time")]
        public int CookingTime { get; set; }

        [Range(MinCountOfPortions, MaxCountOfPortions)]
        [Display(Name = "Count of portions")]
        public int CountOfPortions { get; set; }

        [Range(MinTimeForPreparing, MaxTimeForPreparing)]
        [Display(Name = "Preparing time")]
        public int PreparingTime { get; set; }


        public int CategoryId { get; set; }

        public virtual IEnumerable<RecipeCategorySelectFormModel> Categories { get; set; }

       
        public  string Ingredients { get; set; } = null!;

        public int CookingTypeId { get; set; }

        [Display(Name = "Cooking type")]
        public virtual IEnumerable<RecipeCookingTypeSelectFormModel> CookingTypes { get; set; }

        [Display(Name = "Difficulty")]
        public virtual IEnumerable<RecipeDifficultyTypeSelectFormModel> DifficultyTypes { get; set; }

        public int DifficultyTypeId { get; set; }

        [Display(Name = "Image Link")]
        [StringLength(MaxImageUrlLength, MinimumLength = MinImageUrlLength)]
        public string? ImageUrl { get; set; }
    }
}