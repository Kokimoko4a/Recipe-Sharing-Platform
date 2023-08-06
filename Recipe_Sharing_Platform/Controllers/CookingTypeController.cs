

namespace Recipe_Sharing_Platform.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.CookingType;
    using static RecipeSharingPlatform.Common.NotificationMessagesConstants;
    using static RecipeSharingPlatform.Common.GeneralApplicationConstants;

    public class CookingTypeController : Controller
    {
        private readonly ICookingTypeService cookingTypeService;
        private readonly IMemoryCache memoryCache;

        public CookingTypeController(ICookingTypeService cookingTypeService,
            IMemoryCache memoryCache)
        {
            this.cookingTypeService = cookingTypeService;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        public async Task<IActionResult> ViewCookingTypes()
        {


            IEnumerable<CookingTypeSmallViewModel> cookingTypeSmallViewModels = memoryCache.Get<IEnumerable<CookingTypeSmallViewModel>>(RecipesCacheKey);


            if (cookingTypeSmallViewModels == null)
            {
                cookingTypeSmallViewModels = await cookingTypeService.GetAllCookingTypesAsViewModelsAsync();

                MemoryCacheEntryOptions memoryCacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheRecipesDuration));

                memoryCache.Set(RecipesCacheKey, cookingTypeSmallViewModels, memoryCacheEntryOptions);
            }

            return View(cookingTypeSmallViewModels);

            

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
