namespace Recipe_Sharing_Platform_2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Recipe_Sharing_Platform_2.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Home;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly IRecipeService service;
   

        public HomeController(IRecipeService service)
        {
            this.service = service;        
        }

        public async Task<IActionResult> Index()
        {
            return View(await service.LastSixRecipes());
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