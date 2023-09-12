using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecipeSharingPlatform.Services.Data;
using RecipeSharingPlatform.Services.Data.Interfaces;
using RecipeSharingPlatform.Web.Infrastructure.Extensions;
using System.Text;

namespace Recipe_Sharing_Platform.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
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

        [HttpGet]
        public async Task<IActionResult> DownloadUserData(Guid id)
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
