﻿namespace RecipeSharingPlatform.Common
{
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2023;

        public const int DefaultPage = 1;

        public const int DefaultCountOfRecipesByPage = 6;

        public const string AdminRoleName = "Administrator";

        public const string AdminEmail = "bobi.rusev@abv.bg";

        public const string OnlineUsersCookieName = "IsOnline";

        public const int LastActivityBeforeOfflineMinutes = 5;

        public const string AdminAreaName = "Admin";

        public const string UsersCacheKey = "UsersCacheKey";

        public const string RecipesCacheKey = "RecipesCacheKey";

        public const int CacheUsersDuration = 3;

        public const int CacheRecipesDuration = 3;
    }
}