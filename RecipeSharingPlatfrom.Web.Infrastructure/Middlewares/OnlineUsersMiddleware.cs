namespace RecipeSharingPlatfrom.Web.Infrastructure.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Caching.Memory;
    using RecipeSharingPlatform.Web.Infrastructure.Extensions;
    using System.Collections.Concurrent;
    using static RecipeSharingPlatform.Common.GeneralApplicationConstants;

    public class OnlineUsersMiddleware
    {
        private static readonly ConcurrentDictionary<string, bool> AllKeys = new ConcurrentDictionary<string, bool>();
        
        private readonly RequestDelegate next;
        private readonly string cookieName;
        private readonly int lastActivityMinutes;

        public OnlineUsersMiddleware(RequestDelegate next,
            string cookieName = OnlineUsersCookieName,
            int lastActivityMinutes = LastActivityBeforeOfflineMinutes)
        {
            this.next = next;
            this.cookieName = cookieName;
            this.lastActivityMinutes = lastActivityMinutes;
        }

        public Task InvokeAsync(HttpContext context, IMemoryCache memoryCache)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (!context.Request.Cookies.TryGetValue(cookieName, out string userId))
                {
                    //First logging after being offline
                    userId = context.User.GetId()!;

                    context.Response.Cookies.Append(cookieName, userId, new CookieOptions() { HttpOnly = true, MaxAge = TimeSpan.FromDays(30) });
                }

                memoryCache.GetOrCreate(userId, cacheEntry =>
                {
                    if (!AllKeys.TryAdd(userId, true))
                    {
                        //If something fails 
                        cacheEntry.AbsoluteExpiration = DateTimeOffset.MinValue;
                    }

                    else
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(lastActivityMinutes);

                        cacheEntry.RegisterPostEvictionCallback(RemoveKeyWhenExpired);
                    }

                    return string.Empty;
                });
            }

            else
            {
                if (context.Request.Cookies.TryGetValue(cookieName, out string userId))
                {
                    if (!AllKeys.TryRemove(userId, out _))
                    {
                        AllKeys.TryUpdate(userId, false, true);
                    }

                    context.Response.Cookies.Delete(cookieName);
                }
            }

            return next(context);

        }

        public static bool CheckIfUserIsOnline(string userId)
        {
            bool valueTaken = AllKeys.TryGetValue(userId.ToLower(), out bool success);

            return success && valueTaken;
        }

        private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
        {
            string keyStr = (string)key;

            if (!AllKeys.TryRemove(keyStr, out _))
            {
                AllKeys.TryUpdate(keyStr, false, true);
            }
        }
    }
}
