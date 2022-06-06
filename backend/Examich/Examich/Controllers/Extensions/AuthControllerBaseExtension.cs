using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Examich.Controllers.Extensions
{
    public static class AuthControllerBaseExtension
    {
        public static bool TryGetUserId(this ControllerBase controllerBase, out Guid userId)
        {
            var bearer = controllerBase.User.Claims
                .Where(x => x.Type == ClaimTypes.NameIdentifier)
                .Select(x => x.Value)
                .FirstOrDefault();
            
            /*var env = controllerBase.HttpContext.RequestServices.GetService<IWebHostEnvironment>();
            if (!env.IsProduction())
            {
                return UserSeeder.TryGetUserId(bearer??"", out userId);
            }*/
            
            return Guid.TryParse(bearer
                , out userId);
        }
    }
}