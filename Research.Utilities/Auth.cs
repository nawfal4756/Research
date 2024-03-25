using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Research.Utilities.Enums;

namespace Research.Utilities
{
    public class Auth : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Permissions { get; set; } = string.Empty;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            UserContextData user = new UserContextData();
            user.UserID = int.Parse(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == CustomClaimType.UserId.ToString())?.Value);
            user.UserName = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == CustomClaimType.UserName.ToString())?.Value;
            user.Roles = context.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

            if (Permissions != string.Empty)
            {
                var permissions = Permissions.Split(",");
                if (!user.Roles.Any(x => permissions.Contains(x)))
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }

            context.HttpContext.Items[CONTEXT_USER] = user;
        }
    }
}
