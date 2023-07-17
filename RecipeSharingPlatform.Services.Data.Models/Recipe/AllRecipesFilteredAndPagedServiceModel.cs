
namespace RecipeSharingPlatform.Services.Data.Models.Recipe
{
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class AllRecipesFilteredAndPagedServiceModel
    {
        public AllRecipesFilteredAndPagedServiceModel()
        {
            Recipes = new HashSet<RecipeViewModel>();
        }

        public int TotalRecipesCount { get; set; }

        public virtual IEnumerable<RecipeViewModel> Recipes { get; set; } = null!;
    }
}
