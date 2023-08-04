namespace Recipe_Sharing_Platform_2.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using RecipeSharingPlatform.Services.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.Infrastructure.Extensions;
    using RecipeSharingPlatform.Web.ViewModels.Home;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    using RecipeSharingPlatform.Web.ViewModels.User;
    using static RecipeSharingPlatform.Common.EntityValidationConstants;
    using static RecipeSharingPlatform.Common.GeneralApplicationConstants;

    public class HomeController : Controller
    {
        private readonly IRecipeService service;
      


        public HomeController(IRecipeService service)
        {
            this.service = service;
          
        }

      
        public async Task<IActionResult> Index()
        {
            if (User.IsAdmin())
            {
                return RedirectToAction("Index", "Home", new { Area = AdminAreaName });
            }

            return View(await service.LastThreeRecipesAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 404 || statusCode == 400)
            {
                return View("Error404");
            }

            return View();
        }
    }
}