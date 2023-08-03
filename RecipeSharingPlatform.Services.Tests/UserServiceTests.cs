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
        private IRecipeService recipeService;

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
            recipeService = new RecipeService(data);
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

        [Test]
        public async Task GetUserWithCookedRecipesReturnsUserWithCookedIncludedCookedRecipesCollection()
        {
            int expected = 1;

            ApplicationUser applicationUserExpected = await data.Users.FindAsync(Guid.Parse("5b5d7561-844c-45e9-bd27-fac371fd3296"));

            await userService.AddCookedRecipe("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            ApplicationUser applicationUserActual = await userService.GetUserWithCookedRecipes("5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.That(expected, Is.EqualTo(applicationUserActual.CookedRecipes.Count));
            Assert.That(applicationUserExpected.Id, Is.EqualTo(applicationUserActual.Id));
            Assert.IsNotNull(applicationUserActual.CookedRecipes);
        }

        [Test]
        public async Task AddCookedRecipeAddsRecipeToUserCookedRecipesCollection()
        {
            ApplicationUser applicationUserActual = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == "5b5d7561-844c-45e9-bd27-fac371fd3296");

            await userService.AddCookedRecipe("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.AreEqual(1, applicationUserActual.CookedRecipes.Count);
        }

        [Test]
        public async Task GetCookedRecipesByUserIdReturnsIEnumerableOfRecipeViewModel()
        {
            ApplicationUser applicationUserActual = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == "5b5d7561-844c-45e9-bd27-fac371fd3296");

            await userService.AddCookedRecipe("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            IEnumerable<RecipeViewModel> recipeViewModelsActual = await userService.GetCookedRecipesByUserId("5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.AreEqual(1, recipeViewModelsActual.Count());
        }

        [Test]
        public async Task RemoveCookedRecipeRemovesRecipeFromCookedRecipesCollection()
        {
            int expected = 0;

            ApplicationUser applicationUserActual = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == "5b5d7561-844c-45e9-bd27-fac371fd3296");

            await userService.AddCookedRecipe("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            await userService.RemoveCookedRecipe("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.AreEqual(expected, applicationUserActual.CookedRecipes.Count);

        }

        [Test]
        public async Task MarkRecipeAsFavouriteAsyncAddsRecipeToFavouriteRecipesCollectionOfUser()
        {
            ApplicationUser applicationUserActual = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == "5b5d7561-844c-45e9-bd27-fac371fd3296");

            await userService.MarkRecipeAsFavouriteAsync("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.AreEqual(1, applicationUserActual.FavouriteRecipes.Count);
        }

        [Test]
        public async Task GetFavouriteRecipesByUserIdReturnsIEnumerableOfRecipeViewModelContainingTheFavouriteRecipesOfUser()
        {
            int expected = 1;



            await userService.MarkRecipeAsFavouriteAsync("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            IEnumerable<RecipeViewModel> actualRecipes = await userService.GetFavouriteRecipesByUserId("5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.AreEqual(expected, actualRecipes.Count());
        }

        [Test]
        public async Task MarkRecipeAsUnfavouriteAsyncRemovesRecipeFromUserFavourtireRecipesCollection()
        {
            ApplicationUser applicationUserActual = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == "5b5d7561-844c-45e9-bd27-fac371fd3296");

            await userService.MarkRecipeAsFavouriteAsync("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            await userService.MarkRecipeAsUnfavouriteAsync("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.AreEqual(0, applicationUserActual.FavouriteRecipes.Count);
        }

        [Test]
        public async Task GetFavouriteRecipesByUserIdAsRecipeFullModelReturnsFavoriteRecipesWithInludedAuthor()
        {
            await userService.MarkRecipeAsFavouriteAsync("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            ICollection<Recipe> recipeBigViewModelsActual = await userService.GetFavouriteRecipesByUserIdAsRecipeFullModel("5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.AreEqual(1, recipeBigViewModelsActual.Count);
            Assert.IsNotNull(recipeBigViewModelsActual.First().Author);

        }
    }
}