using System;
using System.Linq;
using System.Security.Claims;
using Examich.Entity.Seed.Seeder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            
            var env = controllerBase.HttpContext.RequestServices.GetService<IWebHostEnvironment>();
            if (!env.IsProduction())
            {
                return UserSeeder.TryGetUserId(bearer??"", out userId);
            }
            
            return Guid.TryParse(bearer
                , out userId);
        }
    }
}