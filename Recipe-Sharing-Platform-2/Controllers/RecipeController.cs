
namespace Recipe_Sharing_Platform_2.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RecipeSharingPlatform.Services.Data.Interfaces;

    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeService service;

        public RecipeController(IRecipeService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
           return View(await service.AllRecipesAsync());
        }
    }
}
