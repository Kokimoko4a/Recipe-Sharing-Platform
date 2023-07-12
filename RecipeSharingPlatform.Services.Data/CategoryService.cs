


namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform_2.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Category;

    public class CategoryService : ICategoryService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public CategoryService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }

        public async Task<IEnumerable<RecipeCategorySelectFormModel>> GetAllCategoriesAsync()
        {
            IEnumerable<RecipeCategorySelectFormModel> categories = await data.Categories
                .Select(c => new RecipeCategorySelectFormModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .AsNoTracking()
                .ToArrayAsync();

            return categories;
        }
    }
}
