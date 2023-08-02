

namespace Recipe_Sharing_Platform.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.CookingType;
    using static RecipeSharingPlatform.Common.NotificationMessagesConstants;

    public class CookingTypeController : Controller
    {
        private readonly ICookingTypeService cookingTypeService;

        public CookingTypeController(ICookingTypeService cookingTypeService)
        {
            this.cookingTypeService = cookingTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> ViewCookingTypes()
        {
            return View(await cookingTypeService.GetAllCookingTypesAsViewModelsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            bool exists1 = await cookingTypeService.ExistsById(id);

            IEnumerable<CookingTypeSmallViewModel> cookingTypeSmallViewModels = await cookingTypeService.GetAllCookingTypesAsViewModelsAsync();

            if (!exists1)
            {
                TempData[WarningMessage] = "No such a cooking type";
                return View("ViewCookingTypes", cookingTypeSmallViewModels);
            }


            try
            {
                return View(await cookingTypeService.GetCookingTypeByIdAsync(id));
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.";

                ModelState.AddModelError(string.Empty, "Unexpected error occurred while trying to create your recipe! Please try again later or contact administrator.");

                return View("ViewCookingTypes", cookingTypeSmallViewModels);


            }
        }
    }
}
