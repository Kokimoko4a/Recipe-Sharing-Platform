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
    using RecipesSharingPlatform.Data.Models;
    using static DatabaseSeeder;

    public class CookingTypeServiceTests
    {
        private RecipeSharingPlatformDbContext data;
        private DbContextOptions<RecipeSharingPlatformDbContext> dbOptions;
        private ICookingTypeService cookingTypeService;

        public CookingTypeServiceTests()
        {

        }


        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<RecipeSharingPlatformDbContext>().UseInMemoryDatabase("RecipeSharingPlatform" + Guid.NewGuid().ToString()).Options;

            data = new RecipeSharingPlatformDbContext(dbOptions);

            data.Database.EnsureCreated();

            SeedDatabase(data);

            cookingTypeService = new CookingTypeService(data);
        }


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task AllCookingTypeNamesAsyncReturnsAllTheNamesOfCookingTypesAsIEnumerableOfString()
        {
            int expectedCount = 14;

            IEnumerable<string> typesActual = await cookingTypeService.AllCookingTypeNamesAsync();

            Assert.AreEqual(expectedCount, typesActual.Count());
        }

        [Test]
        public async Task ExistsByIdReturnsTrueIfCookingTypeExists()
        {
            bool expected = true;

            bool actual = await cookingTypeService.ExistsById(1);

            Assert.AreEqual(expected, actual);
        }

        
        [Test]
        public async Task ExistsByIdReturnsFalseIfCookingTypeDoesNotExist()
        {
            bool expected = false;

            bool actual = await cookingTypeService.ExistsById(-4);

            Assert.AreEqual(expected, actual);
        }
        

        [Test]
        public async Task GetAllCookingTypesAsyncRerurnsAllCookingTypesAsSelectFormModel()
        {
            IEnumerable<RecipeCookingTypeSelectFormModel> recipeCookingTypeSelectFormModelsActual = await cookingTypeService.GetAllCookingTypesAsync();

            int expectedCount = 14;

            Assert.AreEqual(expectedCount, recipeCookingTypeSelectFormModelsActual.Count());


        }

        [Test]
        public async Task GetAllCookingTypesAsViewModelsAsyncReturnsAllCookingTypesAsSmallViewModels()
        { 
            int expectedCount = 13; 

            IEnumerable<CookingTypeSmallViewModel> cookingTypeSmallViewModels  = await cookingTypeService.GetAllCookingTypesAsViewModelsAsync();

            Assert.AreEqual(expectedCount, cookingTypeSmallViewModels.Count());
        }

        [Test]
        public async Task GetCookingTypeByIdAsyncReturnsCookingTypeBigViewModel()
        {

            CookingTypeBigViewModel cookingTypeBigViewModelExpected = new CookingTypeBigViewModel();

            cookingTypeBigViewModelExpected.Description = "A slow cooker, also known as a crock-pot (after a trademark owned by Sunbeam Products but sometimes used generically in the English-speaking world), is a countertop electrical cooking appliance used to simmer at a lower temperature than other cooking methods, such as baking, boiling, and frying. This facilitates unattended cooking for many hours of dishes that would otherwise be boiled: pot roast, soups, stews and other dishes (including beverages, desserts and dips).";
            cookingTypeBigViewModelExpected.Name = "Recipe for Crock-Pot";
            cookingTypeBigViewModelExpected.ImageUrl = "https://images.ctfassets.net/4row1hf0stvo/71uewy1Y0ryTqsFC3ymehf/3279b8bb8ec0013cac5caf1ca94d9cbf/SCCPRC507B-060-MAIN.jpg?w=500&h=399&fl=progressive&q=100&fm=jpg";

            CookingTypeBigViewModel cookingTypeBigViewModelActual = await cookingTypeService.GetCookingTypeByIdAsync(3);

            Assert.AreEqual(cookingTypeBigViewModelExpected.Name, cookingTypeBigViewModelActual.Name);
            Assert.AreEqual(cookingTypeBigViewModelExpected.ImageUrl, cookingTypeBigViewModelActual.ImageUrl);
            Assert.AreEqual(cookingTypeBigViewModelExpected.Description, cookingTypeBigViewModelActual.Description);
        }


        [Test]
        public async Task GetCookingTypeByIdAsyncThrowsArgumentNullExceptionWhencookingTypeNotFound()
        {

            Assert.ThrowsAsync<ArgumentNullException>(async () => { await cookingTypeService.GetCookingTypeByIdAsync(-12); }) ;
        }

    }
}