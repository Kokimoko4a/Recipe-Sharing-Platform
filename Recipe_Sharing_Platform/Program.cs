

namespace Recipe_Sharing_Platform_2
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Recipe_Sharing_Platform.Data;
    using RecipesSharingPlatform.Data.Models;
    using RecipeSharingPlatform.Services.Data.Interfaces;
    using RecipeSharingPlatfrom.Web.Infrastructure.Extensions;
    using RecipeSharingPlatform.Web.Infrastructure.ModelBinders;
    using static RecipeSharingPlatform.Common.GeneralApplicationConstants;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<RecipeSharingPlatformDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<RecipeSharingPlatformDbContext>();

            builder.Services.AddRecaptchaService();



            builder.Services.AddMemoryCache();

            builder.Services.ConfigureApplicationCookie(cfg => cfg.LoginPath = "/User/Login");

            builder.Services.AddApplicationServices(typeof(IRecipeService));

            builder.Services.AddControllersWithViews().AddMvcOptions(options =>
            {
                //  options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
                //options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>(); 

            });

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();

            }

            else
            {
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
                app.UseExceptionHandler("/Home/Error/500");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.EnableOnlineUsersCheck();

            app.SeedAdministrator(AdminEmail);


            app.UseEndpoints(config =>
            {
                config.MapControllerRoute(
name: "areas",
pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}");


                config.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


                config.MapRazorPages();
            });





            app.Run();
        }

    }
}