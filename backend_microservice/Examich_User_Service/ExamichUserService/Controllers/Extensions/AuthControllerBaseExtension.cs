using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace ExamichUserService.Controllers.Extensions
{
    public static class AuthControllerBaseExtension
    {
        public static bool TryGetUserId(this ControllerBase controllerBase, out Guid userId)
        {
            var bearer = controllerBase.User.Claims
                .Where(x => x.Type == ClaimTypes.NameIdentifier)
                .Select(x => x.Value)
                .FirstOrDefault();
            
            return Guid.TryParse(bearer
                , out userId);
        }
    }
}