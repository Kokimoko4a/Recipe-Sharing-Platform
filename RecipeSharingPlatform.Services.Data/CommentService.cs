

namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Comment;
    using RecipesSharingPlatform.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //using static RecipeSharingPlatform.Common.EntityValidationConstants;
   

    public class CommentService : ICommentService
    {
        private readonly RecipeSharingPlatformDbContext data;

        public CommentService(RecipeSharingPlatformDbContext data)
        {
            this.data = data;
        }

        public async Task AddComment(CommentFormModel commentFormModel, string userId)
        {
            Comment comment = new Comment()
            {
                AuthorId = Guid.Parse(userId),
                Content = commentFormModel.Content,
                RecipeId = Guid.Parse(commentFormModel.RecipeId),
               // Author = await data.Users.FirstOrDefaultAsync(u => u.Id.ToString() == userId)
            };

            data.Comments.Add(comment);

            await data.SaveChangesAsync();
        }

      

        public async Task<Comment> GetCommentByIdAsync(string commentId)
        {
            return await data.Comments.FirstOrDefaultAsync(c => c.Id == commentId)!;
        }

        public async Task<ICollection<Comment>> GetComments(string recipeId)
        {
            ICollection<Comment> comments = await data.Comments.Include(c => c.Author).Where(c => c.RecipeId.ToString() == recipeId).ToListAsync();

            return comments;
        }

    }
}
