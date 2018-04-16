using CashFlow.Base.Interfaces;
using CashFlow.Base.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CashFlow.Controllers
{
    public abstract class BaseController<T> : Controller where T : class
    {
        private readonly IResourceHandler _resourceHandler;
        protected readonly IHandler<T> Handler;

        public BaseController(IResourceHandler resourceHandler, IHandler<T> handler)
        {
            this._resourceHandler = resourceHandler;
            this.Handler = handler;
        }

        internal abstract void LoadViewBag();

        public DateTime DateTimeNow
        {
            get
            {
                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "E. South America Standard Time");
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return this.HttpContext.User != null &&
                       this.HttpContext.User.Identity != null &&
                       this.HttpContext.User.Identity.IsAuthenticated;
            }
        }
        public Resource CurrentUser
        {
            get
            {
                var usernameAuthentication = "";
                Resource resource = null;

                if (HttpContext.User.Identity is ClaimsIdentity)
                {
                    usernameAuthentication = (HttpContext.User.Identity as ClaimsIdentity).Claims.Where(c => c.Type == "emails").Select(c => c.Value).First();
                    resource = _resourceHandler.All().FirstOrDefault(u => u.Active && u.Email.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    usernameAuthentication = HttpContext.User.Identity.Name;
                    resource = _resourceHandler.All().FirstOrDefault(u => u.Active && u.Email.Equals(usernameAuthentication, StringComparison.InvariantCultureIgnoreCase));
                }
                if (resource == null)
                {
                    resource = default(Resource);
                    resource.Username = usernameAuthentication;
                }
                return (resource);
            }
        }

        public bool ResourcePermission(string roleName)
        {

            if (CurrentUser == null || CurrentUser.Role != null)
                return false;

            return CurrentUser.Role.Name.Equals(roleName);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Handler.Dispose();
                _resourceHandler.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}