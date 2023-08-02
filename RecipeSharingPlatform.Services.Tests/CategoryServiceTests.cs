namespace RecipeSharingPlatform.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Moq.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipeSharingPlatform.Services.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Category;
    using RecipeSharingPlatform.Web.ViewModels.Comment;
    using RecipesSharingPlatform.Data.Models;
    using static DatabaseSeeder;

    public class CategoryServiceTests
    {
        private RecipeSharingPlatformDbContext data;
        private DbContextOptions<RecipeSharingPlatformDbContext> dbOptions;
        private ICategoryService categoryService;

        public CategoryServiceTests()
        {

        }


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<RecipeSharingPlatformDbContext>().UseInMemoryDatabase("RecipeSharingPlatform" + Guid.NewGuid().ToString()).Options;

            data = new RecipeSharingPlatformDbContext(dbOptions);

            data.Database.EnsureCreated();

            SeedDatabase(data);

            categoryService = new CategoryService(data);
        }


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task AllCategoryNamesAsyncReturnsAllCategoryNamesAsIEnumerableCollectionOfString()
        {
            int expectedCount = 18;

            IEnumerable<string> categoriesActual = await categoryService.AllCategoryNamesAsync();

            Assert.AreEqual(expectedCount, categoriesActual.Count());
        }

        [Test]
        public async Task ExistsByIdReturnsTrueIfCategoryExists()
        {
            bool expected = true;

            bool actual = await categoryService.ExistsById(1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task ExistsByIdReturnsFalseIfCategoryDoesNotExist()
        {
            bool expected = false;

            bool actual = await categoryService.ExistsById(-4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetAllCategoriesAsyncReturnsIEnumerableOfRecipeCategorySelectFormModels()
        {
            IEnumerable<RecipeCategorySelectFormModel> recipeCategorySelectFormModelsActual = await categoryService.GetAllCategoriesAsync();

            int expectedCount = 18;

            Assert.AreEqual(18, recipeCategorySelectFormModelsActual.Count());


        }



    }
}