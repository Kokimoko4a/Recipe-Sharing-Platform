namespace RecipesSharingPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Recipe;

    public class Recipe
    {
        public Recipe()
        {
            Id = Guid.NewGuid();

            Ingredients = new HashSet<Ingredient>();

            CreatedOn = DateTime.Now;

            Comments= new HashSet<Comment>();   
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(MinTimeForCooking, MaxTimeForCooking)]
        public int CookingTime { get; set; }

        [Required]
        [Range(MinCountOfPortions, MaxCountOfPortions)]
        public int CountOfPortions { get; set; }

        [Required]
        [Range(MinTimeForPreparing, MaxTimeForPreparing)]
        public int PreparingTime { get; set; }

        public int TotalTime { get => PreparingTime + CookingTime; protected set { } }

        [Required]
        public virtual Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public virtual ICollection<Ingredient> Ingredients { get; set; } = null!;

        [Required]
        public CookingType CookingType { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(CookingType))]
        public int CookingTypeId { get; set; }

        [Required]
        public DifficultyType Difficulty { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Difficulty))]
        public int DifficultyId { get; set; }

        [Required]
        [MaxLength(MaxImageUrlLength)]
        public string ImageUrl { get; set; } = null!;


        [Required]
        public virtual ApplicationUser? Author { get; set; }


        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]  
        public virtual ICollection<Comment> Comments { get; set; } = null!;

        public int CountBeenCooked { get; set; }
    }
}
