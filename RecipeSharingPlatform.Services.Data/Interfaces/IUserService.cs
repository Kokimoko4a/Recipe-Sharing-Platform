namespace RecipeSharingPlatform.Services.Data.Interfaces
{

    public interface IUserService
    {
        Task<string> GetNameByEmailAsync(string email);
    }
}
