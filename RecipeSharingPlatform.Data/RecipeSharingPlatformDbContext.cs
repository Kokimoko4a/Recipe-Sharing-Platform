

namespace Recipe_Sharing_Platform.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RecipeSharingPlatform.Data.Models;

    public class RecipeSharingPlatformDbContext : IdentityDbContext
    {
        public RecipeSharingPlatformDbContext(DbContextOptions<RecipeSharingPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
    }
}