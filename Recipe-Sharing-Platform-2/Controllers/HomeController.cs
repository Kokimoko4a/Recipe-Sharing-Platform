using Microsoft.AspNetCore.Mvc;
using Recipe_Sharing_Platform_2.Data;
using RecipeSharingPlatform.Data.Models;
using RecipeSharingPlatform.Web.ViewModels.Home;
//using Recipe_Sharing_Platform_2.Models;
using System.Diagnostics;

namespace Recipe_Sharing_Platform_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecipeSharingPlatformDbContext dbContext;
   

        public HomeController(RecipeSharingPlatformDbContext dbContext)
        {
            this.dbContext = dbContext;        
        }

        public IActionResult Index()
        {
           List<RecipeViewModel> recipes = dbContext.Recipes.Select(x => new RecipeViewModel()
           { 
            AuthorName = x.Author!.Email,
            ImageURL = x.ImageUrl,
            Title = x.Name
           }).ToList();

            return View(recipes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}