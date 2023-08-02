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


    public class RecipeServiceTests
    {
        private RecipeSharingPlatformDbContext data;
        private DbContextOptions<RecipeSharingPlatformDbContext> dbOptions;
        private IRecipeService recipeService;

        public RecipeServiceTests()
        {

        }


        [SetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<RecipeSharingPlatformDbContext>().UseInMemoryDatabase("RecipeSharingPlatform" + Guid.NewGuid().ToString()).Options;

            data = new RecipeSharingPlatformDbContext(dbOptions);

            data.Database.EnsureCreated();

            SeedDatabase(data);

            recipeService = new RecipeService(data);
        }


        [SetUp]
        public void Setup()
        {

        }



        [Test]
        public async Task LastThreeRecipesAsyncReturnsTheLatesPublishedThreeRecipes()
        {

            int expectedCount = 3;
            string expectedId1 = "b8c3e305-4425-43e7-a294-570eceb5ac13";
            string expectedId2 = "b7c3e305-4425-43e7-a294-570eceb5ac13";
            string expectedId3 = "b9c3e305-4425-43e7-a294-570eceb5ac13";

            IEnumerable<IndexViewModel> actualRecipes = await recipeService.LastThreeRecipesAsync();


            IndexViewModel indexViewModel1 = actualRecipes.FirstOrDefault(r => r.Title == "ffffffffkkkkkkkkffffff");
            IndexViewModel indexViewModel2 = actualRecipes.FirstOrDefault(r => r.Title == "fffffggggggffffffffff");
            IndexViewModel indexViewModel3 = actualRecipes.FirstOrDefault(r => r.Title == "ffffffffffffffffffff");

            Assert.That(expectedCount, Is.EqualTo(actualRecipes.Count()));

            Assert.That(expectedId3, Is.EqualTo(indexViewModel1.Id.ToString()));
            Assert.That(expectedId2, Is.EqualTo(indexViewModel2.Id.ToString()));
            Assert.That(expectedId1, Is.EqualTo(indexViewModel3.Id.ToString()));
        }

        [Test]
        public async Task GetRecipeByIdAsyncReturnsRecipeBigViewModelAndSetsGuestUserNotNullWhenUserIdIsNotNullOrEmpty()
        {
            RecipeBigViewModel recipeBigViewModelActual = await recipeService.GetRecipeByIdAsync("b8c3e305-4425-43e7-a294-570eceb5ac13", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            string expectedTitleOfRecipe = "ffffffffffffffffffff";

            Assert.That(expectedTitleOfRecipe, Is.EqualTo(recipeBigViewModelActual.Title));
            Assert.IsNotNull(recipeBigViewModelActual.GuestUser);


        }

        [Test]
        public async Task GetRecipeByIdAsyncReturnsRecipeBigViewModelAndSetsGuestUserNULLWhenUserIdIsNULL()
        {
            RecipeBigViewModel recipeBigViewModelActual = await recipeService.GetRecipeByIdAsync("b8c3e305-4425-43e7-a294-570eceb5ac13", null);

            Assert.IsNull(recipeBigViewModelActual.GuestUser);


        }

        [Test]
        public async Task GetRecipeByIdAsyncReturnsRecipeBigViewModelAndSetsGuestUserNULLWhenUserIdIsEmpty()
        {
            RecipeBigViewModel recipeBigViewModelActual = await recipeService.GetRecipeByIdAsync("b8c3e305-4425-43e7-a294-570eceb5ac13", string.Empty);

            Assert.IsNull(recipeBigViewModelActual.GuestUser);
        }

        [Test]
        public async Task GetRecipeAsFormModelReturnsRecipeFormModelOfTheCurrentRecipe()
        {
            string expectedTitle = "ffffffffffffffffffff";

            RecipeFormModel recipeFormModelActual = await recipeService.GetRecipeAsFormModel("b8c3e305-4425-43e7-a294-570eceb5ac13");

            Assert.IsNotNull(recipeFormModelActual);
            Assert.That(expectedTitle, Is.EqualTo(recipeFormModelActual.Title));

        }

        [Test]
        public async Task ExistsByIdAsyncReturnsTrueIfRecipeIdExists()
        {
            bool actual = await recipeService.ExistsByIdAsync("b8c3e305-4425-43e7-a294-570eceb5ac13");

            Assert.IsTrue(actual);
        }

        [Test]
        public async Task ExistsByIdAsyncReturnsFalseIfRecipeIdDoesNotExistExists()
        {
            bool actual = await recipeService.ExistsByIdAsync("ygkubyfgu");

            Assert.IsFalse(actual);
        }

        [Test]
        public async Task GetAllRecipesByUserIdReturnsIEnumerableOfRecipeViewModel()
        {
            int expectedCount = 3;

            IEnumerable<RecipeViewModel> recipeViewModelsActual = await recipeService.GetAllRecipesByUserId("5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.IsNotNull(recipeViewModelsActual);
            Assert.That(expectedCount, Is.EqualTo(recipeViewModelsActual.Count()));
        }

        [Test]
        public async Task IsRecipeYoursReturnsTrueIfRecipeBelongsToUser()
        {
            bool actual = await recipeService.IsRecipeYours("5b5d7561-844c-45e9-bd27-fac371fd3296", "b8c3e305-4425-43e7-a294-570eceb5ac13");

            Assert.IsTrue(actual);
        }

        [Test]
        public async Task IsRecipeYoursReturnsFalseIfRecipeDoesNotBelongToUser()
        {
            bool actual = await recipeService.IsRecipeYours("5b5d71fd3296", "b8c3e305-4425-43e7-a294-570eceb5ac13");

            Assert.IsFalse(actual);
        }


        [Test]
        public async Task DeleteAsyncRemovesTheRecipeAndItsIngredients()
        {
            await recipeService.DeleteAsync("b8c3e305-4425-43e7-a294-570eceb5ac13");

            Recipe recipeActual = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == "b8c3e305-4425-43e7-a294-570eceb5ac13");
            Ingredient ingredientActual = await data.Ingredients.FirstOrDefaultAsync(i => i.Id == 1);

            Assert.IsNull(recipeActual);
            Assert.IsNull(ingredientActual);

        }

        [Test]
        public async Task MarkAsCookedRecipeIncrementTheCountIfRecipeBeenCooked()
        {
            int expected = 1;

            await recipeService.MarkAsCookedRecipe("b8c3e305-4425-43e7-a294-570eceb5ac13");

            Recipe recipe = data.Recipes.Find(Guid.Parse("b8c3e305-4425-43e7-a294-570eceb5ac13"));

            Assert.That(expected, Is.EqualTo(recipe.CountBeenCooked));
        }


        [Test]
        public async Task MarkAsCookedRecipeDecrementTheCountIfRecipeBeenUnCooked()
        {
            int expected = -1;

            await recipeService.MarkAsUnCookedRecipe("b8c3e305-4425-43e7-a294-570eceb5ac13");

            Recipe recipe = data.Recipes.Find(Guid.Parse("b8c3e305-4425-43e7-a294-570eceb5ac13"));

            Assert.That(expected, Is.EqualTo(recipe.CountBeenCooked));
        }

        [Test]
        public async Task CreateIngredientsReturnsICollectionOfIngredients()
        {
            string expected = "ddd ";

            RecipeFormModel recipeFormModel = new RecipeFormModel()
            {

                Ingredients = "ddd - 1 kg"
            };

            ICollection<Ingredient> ingredientsActual = recipeService.CreateIngredients(recipeFormModel);

            Ingredient ingredientActual = ingredientsActual.FirstOrDefault(i => i.Name == "ddd ");



            Assert.That(expected, Is.EqualTo(ingredientActual!.Name));

        }

        [Test]
        public async Task CreateRecipeAsyncAddsRecipeToDb()
        {
            int expected = 4;

            RecipeFormModel recipeFormModel = new RecipeFormModel()
            {
                Description = "lkjrvmpoiroj,t",
                DifficultyTypeId = 1,
                CategoryId = 1,
                CookingTime = 1,
                CookingTypeId = 1,
                CountOfPortions = 1,
                Id = "89fc5513-7250-4c81-a834-141f9e906f2c",
                ImageUrl = "https://www.seriouseats.com/thmb/uH_msyHurzKTDRzc4c_goGoLANI=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/SEA-classic-panzanella-salad-recipe-hero-03-74d7b17dde8f498795387ef0c22d7215.jpg",
                PreparingTime = 1,
                Title = "dddddddd",
                Ingredients = "ddd - 1 kg"
            };

            await recipeService.CreateRecipeAsync(recipeFormModel, "5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.That(expected, Is.EqualTo(data.Recipes.Count()));
        }

        [Test]
        public async Task EditUpdatesInfoAboutRecipe()
        {

            RecipeFormModel recipeFormModel = new RecipeFormModel()
            {
                Description = "lkjrvmpoiroj,t",
                DifficultyTypeId = 1,
                CategoryId = 1,
                CookingTime = 1,
                CookingTypeId = 1,
                CountOfPortions = 1,
                Id = "b8c3e305-4425-43e7-a294-570eceb5ac13",
                ImageUrl = "https://www.seriouseats.com/thmb/uH_msyHurzKTDRzc4c_goGoLANI=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/SEA-classic-panzanella-salad-recipe-hero-03-74d7b17dde8f498795387ef0c22d7215.jpg",
                PreparingTime = 1,
                Title = "dddddddd",
                Ingredients = "ddd - 1 kg"
            };


            await recipeService.EditRecipeAsync(recipeFormModel);

            Recipe recipeActual = await data.Recipes.FirstOrDefaultAsync(r => r.Id.ToString() == "b8c3e305-4425-43e7-a294-570eceb5ac13"); 

            Assert.That(recipeFormModel.Description, Is.EqualTo(recipeActual.Description));

        }

       
    }
}