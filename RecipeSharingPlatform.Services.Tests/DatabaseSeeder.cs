﻿using Recipe_Sharing_Platform.Data;
using RecipesSharingPlatform.Data.Models;

namespace RecipeSharingPlatform.Services.Tests
{
    public static class DatabaseSeeder
    {
        private static Comment comment1;
        private static Recipe recipe;
        private static ApplicationUser cooker;

       

        public static List<Comment> Comments = new List<Comment>()
        {
            new Comment()
            {
                AuthorId = Guid.Parse("7C1BEEF3-2EF8-4CA7-98C7-96AEB89784BF"),
                Content = "dddddddd",
                RecipeId = Guid.Parse("b8c3e305-4425-43e7-a294-570eceb5ac13")

            }
        };

        public static void SeedDatabase(RecipeSharingPlatformDbContext data)
        {          

            cooker = new ApplicationUser()
            {
                UserName = "Pesho",
                NormalizedUserName = "PESHO",
                Email = "pesho@agents.com",
                NormalizedEmail = "PESHO@AGENTS.COM",
                EmailConfirmed = true,
                PasswordHash = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                ConcurrencyStamp = "caf271d7-0ba7-4ab1-8d8d-6d0e3711c27d",
                SecurityStamp = "ca32c787-626e-4234-a4e4-8c94d85a2b1c",
                TwoFactorEnabled = false,
                FirstName = "Pesho",
                LastName = "Petrov",
                Id = Guid.Parse("5b5d7561-844c-45e9-bd27-fac371fd3296")
            };

            data.Users.Add(cooker);

            comment1 = new Comment()
            {
                AuthorId = Guid.Parse("7C1BEEF3-2EF8-4CA7-98C7-96AEB89784BF"),
                Content = "dddddddd",
                RecipeId = Guid.Parse("b8c3e305-4425-43e7-a294-570eceb5ac13")

            };

            data.Comments.Add(comment1);

            comment1 = new Comment()
            {
                AuthorId = Guid.Parse("5b5d7561-844c-45e9-bd27-fac371fd3296"),
                Content = "dddsdddd",
                RecipeId = Guid.Parse("b8c3e305-4425-43e7-a294-570eceb5ac13"),
                Id = "b2dac8a9-f16b-4095-ae08-32701774e1ef"

            };

            data.Comments.Add(comment1);

            recipe = new Recipe()
            {
                Description = "ddddddddddddddddddddd",
                DifficultyId = 1,
                AuthorId = Guid.Parse("5b5d7561-844c-45e9-bd27-fac371fd3296"),
                CategoryId = 1,
                CookingTime = 1,
                CookingTypeId = 1,
                CountOfPortions = 1,
                ImageUrl = "ffffffffffffffffff",
                PreparingTime = 1,
                Title = "ffffffffffffffffffff",
                Id = Guid.Parse("b8c3e305-4425-43e7-a294-570eceb5ac13")
            };

            data.Recipes.Add(recipe);

            data.SaveChanges();

        }
    }
}