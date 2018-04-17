using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;

namespace CashFlow
{
    public static class HtmlExtensions
    {
        public static Resource ResourceInfo<T>(this HtmlHelper<T> html)
        {
            if (html == null)
                throw new ArgumentNullException("html");

            var db = new CashFlow.Handler.CashFlowContext();
            var usernameAuthentication = "";
            Resource resource = null;

            if (html.ViewContext.HttpContext.User.Identity is ClaimsIdentity)
            {
                usernameAuthentication = (html.ViewContext.HttpContext.User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == "emails").Select(c => c.Value).FirstOrDefault();
                if (usernameAuthentication != null)
                {
                    resource = db.Resource.Include("Role").FirstOrDefault(u => u.Email.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase));

                }
            }
            else
            {
                usernameAuthentication = html.ViewContext.HttpContext.User.Identity.Name;
                resource = db.Resource.Include("Role").FirstOrDefault(u => u.Username.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase));
            }

            return (resource);
        }

        public static bool ResourcePermission<T>(this HtmlHelper<T> html, string roleName)
        {
            var user = ResourceInfo(html);

            if (user == null || user.Role == null)
                return false;

            return user.Role.Name.Equals(roleName);
        }
    }
}