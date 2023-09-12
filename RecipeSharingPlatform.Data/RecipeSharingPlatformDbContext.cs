namespace Recipe_Sharing_Platform.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using RecipesSharingPlatform.Data.Models;
    using System.Reflection;

    public class RecipeSharingPlatformDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public RecipeSharingPlatformDbContext(DbContextOptions<RecipeSharingPlatformDbContext> options)
           : base(options)
        {

            if (Database.IsRelational())
            {
                Database.EnsureCreated();
            }
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Ingredient> Ingredients { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;

        public DbSet<CookingType> CookingTypes { get; set; } = null!;

        public DbSet<DifficultyType> DifficultyTypes { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
     


            Assembly configAssembly = Assembly.GetAssembly(typeof(RecipeSharingPlatformDbContext)) ??
                                     Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }

    }
}