

namespace Recipe_Sharing_Platform.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.User;
    using static RecipeSharingPlatform.Common.GeneralApplicationConstants;

    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public HomeController(IUserService userService,
            IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> GetAllUsers()
        {
            ICollection<UserViewModel> users = memoryCache.Get<ICollection<UserViewModel>>(UsersCacheKey);

            if (users == null)
            {
                users = await userService.GetAllUsersAsViewModel();

                MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheUsersDuration));

                memoryCache.Set(UsersCacheKey, users, cacheEntryOptions);
            }



            return View(users);
        }
    }
}
