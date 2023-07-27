namespace RecipeSharingPlatform.Web.ViewModels.Recipe
{
    public class RecipeViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string AuthorName { get; set; } = null!;

        public string ImageURL { get; set; } = null!;

        /*  public string Category { get; set; } = null!;

          public string CookingType { get; set; } = null!;

          public string DifficultyType { get; set; } = null!;*/

        public int CountBeenCooked { get; set; }
    }
}