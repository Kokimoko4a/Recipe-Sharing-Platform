namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipesSharingPlatform.Data.Models;

    public class UserService : IUserService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public UserService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }

        public async Task<string> GetNameByEmailAsync(string email)
        {
            ApplicationUser user = await data.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user!.FirstName} {user.LastName}";
        }
    }
}
