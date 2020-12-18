using System.Linq;
using Microsoft.AspNetCore.Http;

namespace api.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserIdFromRequest(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return string.Empty;
            }

            return httpContext.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}