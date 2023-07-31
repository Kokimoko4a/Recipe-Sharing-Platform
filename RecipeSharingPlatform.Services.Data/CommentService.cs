

namespace RecipeSharingPlatform.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatform.Web.ViewModels.Comment;
    using RecipesSharingPlatform.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
   

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

           

        public async Task<ICollection<Comment>> GetComments(string recipeId)
        {
            ICollection<Comment> comments = await data.Comments.Include(c => c.Author).Where(c => c.RecipeId.ToString() == recipeId).ToListAsync();

            return comments;
        }

        public async Task<Comment> GetCommentByIdAsync(string commentId)
        {
            return await data.Comments.FirstOrDefaultAsync(c => c.Id == commentId)!;
        }

        public async Task<bool> ExistsById(string commentId)
        {
            return await data.Comments.AnyAsync(c => c.Id == commentId);
        }

        public async Task<bool> IsCommentYours(string commentId, string userId)
        {
            Comment comment = await data.Comments.FirstOrDefaultAsync(c => c.Id == commentId);

            return comment!.AuthorId.ToString() == userId ? true : false;

        }

        public async Task DeleteCommentByIdAsync(string commentId)
        {
            Comment comment = await data.Comments.FirstOrDefaultAsync(c => c.Id == commentId);

            data.Comments.Remove(comment);

            await data.SaveChangesAsync();
        }
    }
}
