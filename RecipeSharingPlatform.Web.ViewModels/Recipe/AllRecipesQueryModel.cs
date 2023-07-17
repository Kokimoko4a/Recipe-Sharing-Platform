

namespace RecipeSharingPlatform.Web.ViewModels.Recipe
{


    using System.ComponentModel.DataAnnotations;
    using static RecipeSharingPlatform.Common.GeneralApplicationConstants;

    public class AllRecipesQueryModel
    {
        public AllRecipesQueryModel()
        {
            CurrentPage = DefaultPage;
            RecipesByPage = DefaultCountOfRecipesByPage;

            Categories = new HashSet<string>();
            DifficultyTypes = new HashSet<string>();
            CookingTypes = new HashSet<string>();
            Recipes = new HashSet<RecipeViewModel>();
        }

        public string? Category { get; set; }
        public string? CookingType { get; set; }
        public string? DifficultyType { get; set; }

        [Display(Name = "Search by text")]
        public string? SearchString { get; set; }

        public int TotalRecipes { get; set; }

        public int RecipesByPage { get; set; }

        public int  CurrentPage { get; set; }

        public virtual IEnumerable<string> Categories { get; set; }
        public virtual IEnumerable<string> DifficultyTypes { get; set; }
        public virtual IEnumerable<string> CookingTypes { get; set; }

        public virtual IEnumerable<RecipeViewModel> Recipes { get; set; }
    }
}
