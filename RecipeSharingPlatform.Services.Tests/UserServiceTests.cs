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
    using RecipeSharingPlatform.Web.ViewModels.CookingType;
    using RecipeSharingPlatform.Web.ViewModels.DifficultyType;
    using RecipeSharingPlatform.Web.ViewModels.Home;
    using RecipeSharingPlatform.Web.ViewModels.Recipe;
    using RecipesSharingPlatform.Data.Models;
    using static DatabaseSeeder;


    public class UserServiceTests
    {
        private RecipeSharingPlatformDbContext data;
        private DbContextOptions<RecipeSharingPlatformDbContext> dbOptions;
        private IUserService userService;

        public UserServiceTests()
        {

        }


        [SetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<RecipeSharingPlatformDbContext>().UseInMemoryDatabase("RecipeSharingPlatform" + Guid.NewGuid().ToString()).Options;

            data = new RecipeSharingPlatformDbContext(dbOptions);

            data.Database.EnsureCreated();

            SeedDatabase(data);

            userService = new UserService(data);
        }


        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public async Task GetNameByEmailAsyncReturnsTheNameOfUserFound()
        {
            string expectedNames = "Pesho Petrov";

            string actualNames = await userService.GetNameByEmailAsync("pesho@cooker.com");

            Assert.That(expectedNames, Is.EqualTo(actualNames));
        }

        [Test]
        public async Task GetNameByEmailAsyncReturnsNULLWhenNotFound()
        {
            string expectedNames = "Pesho Petrov";

            string actualNames = await userService.GetNameByEmailAsync("pesho@cooker.bg");

           Assert.AreEqual(string.Empty, actualNames);
        }

        [Test]
        public async Task GetNameByEmailAsyncReturnsNULLWhenNotFound2()
        {
            string expectedNames = "Pesho Petrov";

            string actualNames = await userService.GetNameByEmailAsync(null);

            Assert.AreEqual(string.Empty, actualNames);
        }

        [Test]
        public async Task GetNameByEmailAsyncReturnsNULLWhenNotFound3()
        {
            string expectedNames = "Pesho Petrov";

            string actualNames = await userService.GetNameByEmailAsync(string.Empty);

            Assert.AreEqual(string.Empty, actualNames);
        }
    }
}