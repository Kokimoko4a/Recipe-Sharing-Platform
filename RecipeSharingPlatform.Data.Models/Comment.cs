

namespace RecipesSharingPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static RecipeSharingPlatform.Common.EntityValidationConstants.Comment;

    public class Comment
    {
        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; } = null!;

        [Required]
        [StringLength(MaxTextLength, MinimumLength = MinTextLength)]
        public string Content { get; set; } = null!;

        [Required]
        public ApplicationUser Author { get; set; } = null!;

        [ForeignKey(nameof(Author))]
        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }

        [Required]
        public Recipe Recipe { get; set; } = null!;
    }
}
