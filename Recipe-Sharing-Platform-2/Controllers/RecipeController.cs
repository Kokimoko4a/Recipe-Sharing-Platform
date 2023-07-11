
namespace Recipe_Sharing_Platform_2.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class RecipeController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
           return View();
        }
    }
}
