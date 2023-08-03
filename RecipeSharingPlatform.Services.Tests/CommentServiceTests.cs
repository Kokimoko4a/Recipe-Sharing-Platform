namespace RecipeSharingPlatform.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Moq.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipeSharingPlatform.Services.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Comment;
    using RecipesSharingPlatform.Data.Models;
    using static DatabaseSeeder;

    public class CommentServiceTests
    {
        private  RecipeSharingPlatformDbContext data;
        private  DbContextOptions<RecipeSharingPlatformDbContext> dbOptions;
        private ICommentService commentService;

        public CommentServiceTests()
        {

        }


        [SetUp]
        public void OneTimeSetup()
        {
            dbOptions = new DbContextOptionsBuilder<RecipeSharingPlatformDbContext>().UseInMemoryDatabase("RecipeSharingPlatform" + Guid.NewGuid().ToString()).Options;

            data = new RecipeSharingPlatformDbContext(dbOptions);

            data.Database.EnsureCreated();

            SeedDatabase(data);
        }


        [SetUp]
        public void Setup()
        {
            commentService = new CommentService(data);
        }

        [Test]
        public async Task AddCommentShouldAddCommentToDB()
        {
           

            CommentFormModel commentFormModel = new CommentFormModel()
            {
                Content = "ffffffff",
                RecipeId = "b8c3e305-4425-43e7-a294-570eceb5ac13"
            };

            await commentService.AddComment(commentFormModel, "72095EFF-7D9A-4F5D-B84A-7BE5E8703865");

          Comment actualComment =  await data.Comments.FirstOrDefaultAsync(c => c.AuthorId.ToString() == "72095EFF-7D9A-4F5D-B84A-7BE5E8703865".ToLower());

            Assert.AreEqual(commentFormModel.Content, actualComment.Content);
        }


        [Test]
        public async Task GetCommentsReturnsCommentsForRecipe()
        {
           

            ICollection<Comment> commentsActual = await commentService.GetComments("b8c3e305-4425-43e7-a294-570eceb5ac13");

            Assert.AreEqual(3, commentsActual.Count);
        }


        [Test]
        public async Task GetCommentReturnsComment()
        {
            Comment expected = await data.Comments.FindAsync("b2dac8a9-f16b-4095-ae08-32701774e1ef");

            Comment actual = await commentService.GetCommentByIdAsync("b2dac8a9-f16b-4095-ae08-32701774e1ef");

            Assert.AreEqual(expected.Id, actual.Id);
        }

        [Test]
        public async Task ExistsByIdReturnsTrueIfCommentExists()
        {
            bool actual = await commentService.ExistsById("b2dac8a9-f16b-4095-ae08-32701774e1ef");

            Assert.IsTrue(actual);
        }


        [Test]
        public async Task ExistsByIdReturnsFalseIfCommentDoesNotExists()
        {
            bool actual = await commentService.ExistsById("b2dac8a9-f16b-4095-ae08-32701774e1f");

            Assert.IsFalse(actual);
        }

        [Test]
        public async Task IsCommentYoursReturnsTrueIfCommentIsYours()
        {
            bool actual = await commentService.IsCommentYours("b2dac8a9-f16b-4095-ae08-32701774e1ef", "5b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.IsTrue(actual);
        }


        [Test]
        public async Task IsCommentYoursReturnsFalseIfCommentIsNotYours()
        {
            bool actual = await commentService.IsCommentYours("b2dac8a9-f16b-4095-ae08-32701774e1ef", "6b5d7561-844c-45e9-bd27-fac371fd3296");

            Assert.IsFalse(actual);
        }

        [Test]
        public async Task DeleteRemovesAComment()
        {
            int expectedCount = 1;

           await commentService.DeleteCommentByIdAsync("b2dac8a9-f16b-4095-ae08-32701774e1ef");

            Assert.AreEqual(expectedCount, data.Comments.Count());

        }

        [Test]
        public async Task DeleteThrowsAnExceptionWhenNotFoundTheComment()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => { await commentService.DeleteCommentByIdAsync("babati"); });

        }

        [Test]
        public async Task GetCommentAsFormModelAsyncReturnsCommentFormModelWithCorrectData()
        {
            CommentFormModel expected = new CommentFormModel()
            {
                CommentId = "b2dac8a9-f16b-4095-ae08-32701774e1ef",
                Content = "dddsdddd",
                RecipeId = "b8c3e305-4425-43e7-a294-570eceb5ac13"
            };

            CommentFormModel actual = await commentService.GetCommentAsFormModelAsync("b2dac8a9-f16b-4095-ae08-32701774e1ef");

            Assert.AreEqual(expected.CommentId, actual.CommentId);
            Assert.AreEqual(expected.RecipeId, actual.RecipeId);
            Assert.AreEqual(expected.Content, actual.Content);

        }


        [Test]
        public async Task  GetCommentAsFormModelAsyncThrowsArgumetnNullExceptionWhenIdIsNotFound()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => { CommentFormModel commentFormModel = await commentService.GetCommentAsFormModelAsync("babati"); });

        }

        [Test]
        public async Task UpdateUpdatesTheInfoAboutComment()
        {
            CommentFormModel commentForm = await commentService.GetCommentAsFormModelAsync("b2dac8a9-f16b-4095-ae08-32701774e1ef");

            commentForm.Content = "Dade mi sin ekran dokato go pisah i ma prati v BIOS-a. Enjoy ;)";

            await commentService.UpdateData(commentForm);

            Comment actual = await commentService.GetCommentByIdAsync("b2dac8a9-f16b-4095-ae08-32701774e1ef");

            Assert.AreEqual(commentForm.Content, actual.Content);
        }

        [Test]
        public async Task UpdateThrowsAnExceptionWhenCommentNotFound()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await commentService.UpdateData(new CommentFormModel()
                {
                    CommentId = "babati",
                    Content = "mdaoksdp",
                    RecipeId = "dddafp[kgosr"

                });
            });
        }


    }
}