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
    using RecipesSharingPlatform.Data.Models;
    using static DatabaseSeeder;
    using static RecipeSharingPlatform.Common.EntityValidationConstants;

    public class DifficultyTypeServiceTests
    {
        private RecipeSharingPlatformDbContext data;
        private DbContextOptions<RecipeSharingPlatformDbContext> dbOptions;
        private IDifficultyTypesService difficultyTypesService;

        public DifficultyTypeServiceTests()
        {

        }


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<RecipeSharingPlatformDbContext>().UseInMemoryDatabase("RecipeSharingPlatform" + Guid.NewGuid().ToString()).Options;

            data = new RecipeSharingPlatformDbContext(dbOptions);

            data.Database.EnsureCreated();

            SeedDatabase(data);

            difficultyTypesService = new DifficultyTypesService(data);
        }


        [SetUp]
        public void Setup()
        {

        }



        [Test]
        public async Task AllDifficultyTypeNamesAsyncReturnsIEnumerableOfStringWithNameOfDifficultyTypes()
        {
            int expected = 4;

            IEnumerable<string> difficultyTypes = await difficultyTypesService.AllDifficultyTypeNamesAsync();

            Assert.That(expected, Is.EqualTo(difficultyTypes.Count()));
        }

        [Test]
        public async Task ExistsByIdReturnsTrueIfDifficultyTypeExists()
        {
            bool actual = await difficultyTypesService.ExistsById(1);

            Assert.That(actual, Is.True);

        }

        [Test]
        public async Task ExistsByIdReturnsFaleIfDifficultyTypeDoesNotExist()
        {
            bool actual = await difficultyTypesService.ExistsById(-12);

            Assert.That(actual, Is.False);

        }

        [Test]
        public async Task GetAllDifficultyTypesAsyncReturnsIEnumerableOfSelectFormModel()
        {
            int expected = 4;

            IEnumerable<RecipeDifficultyTypeSelectFormModel> recipeDifficultyTypeSelectFormModels  = await difficultyTypesService.GetAllDifficultyTypesAsync();

            Assert.That(expected, Is.EqualTo(recipeDifficultyTypeSelectFormModels.Count()));
        }
    }
}