namespace RecipeSharingPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Comment;
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public virtual ApplicationUser Author { get; set; } = null!;

        [ForeignKey(nameof(Author))]
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(MaxTextLength, MinimumLength = MinTextLength)]
        public string Content { get; set; } = null!;

        [Required]
        public int Likes { get; set; }

        [Required]
        public int Dislikes { get; set; }

        [Required]
        public virtual Recipe Recipe { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }
    }
}
