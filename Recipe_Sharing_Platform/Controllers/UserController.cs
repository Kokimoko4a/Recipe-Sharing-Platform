

namespace Recipe_Sharing_Platform.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using RecipesSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Web.ViewModels.User;
    using static RecipeSharingPlatform.Common.NotificationMessagesConstants;
    using Griesoft.AspNetCore.ReCaptcha;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using Microsoft.Extensions.Caching.Memory;
    using static RecipeSharingPlatform.Common.GeneralApplicationConstants;
    using RecipeSharingPlatform.Web.Infrastructure.Extensions;
    using Newtonsoft.Json;
    using System.Text;


    // using System.Web.SessionState.HttpSessionState;

    public class UserController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMemoryCache memoryCache;
        private readonly IUserService userService;


        public UserController(SignInManager<ApplicationUser> signInManager,
                              UserManager<ApplicationUser> userManager,
                              IMemoryCache memoryCache,
                              IUserService userService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateRecaptcha(Action = nameof(Register),
             ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
        public async Task<IActionResult> Register(RecipeSharingPlatform.Web.ViewModels.User.RegisterFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await userManager.SetEmailAsync(user, model.Email);
            await userManager.SetUserNameAsync(user, model.Email);

            IdentityResult result =
                await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            await signInManager.SignInAsync(user, false);

            memoryCache.Remove(UsersCacheKey);

            TempData[SuccessMessage] = "Succesfully made account";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =
                await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                TempData[ErrorMessage] =
                    "There was an error while logging you in! Your password can be incorrect! Please try again or contact an administrator.";

                return View(model);
            }

            return Redirect(model.ReturnUrl ?? "/Home/Index");
        }

        [HttpGet]
        public async Task<IActionResult> ViewProfile(Guid id)
        {
            if (User.GetId() != id.ToString())
            {
                return BadRequest();
            }

            if (await userService.GetAllInfoAboutUserByIdAsync(id) == null)
            {
                return BadRequest();
            }

            return View(await userService.GetAllInfoAboutUserByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            if (await userService.GetAllInfoAboutUserByIdAsync(id) == null)
            {
                return BadRequest();
            }

            if (User.GetId() != id.ToString())
            {
                return BadRequest();
            }

            await userService.DeleteUserInfo(id);


            return RedirectToAction("Logout", "User");
                 
        }


       
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            TempData[SuccessMessage] = "You successfully deleted your account";

            return RedirectToAction("Index", "Home");
        }

        public async Task<FileResult> DownloadUserData(Guid id)
        {
            /* Retrieve user data and serialize it*/
            var userData = await userService.GetUserDataForCurrentUser(id);
            var serializedData = JsonConvert.SerializeObject(userData); /*Convert the serialized data to bytes*/
            byte[] dataBytes = Encoding.UTF8.GetBytes(serializedData);
            /*Set the content type and return the file for download*/
            return File(dataBytes, "application/json", "user_data.json");
        }
    }
}

