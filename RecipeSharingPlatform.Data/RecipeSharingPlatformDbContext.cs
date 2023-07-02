

namespace Recipe_Sharing_Platform_2.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RecipeSharingPlatform.Data.Models;
    using System.Reflection;

    public class RecipeSharingPlatformDbContext : IdentityDbContext<ApplicationUser,IdentityRole<Guid>,Guid>
    {
        public RecipeSharingPlatformDbContext(DbContextOptions<RecipeSharingPlatformDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(RecipeSharingPlatformDbContext)) ??
                                     Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}