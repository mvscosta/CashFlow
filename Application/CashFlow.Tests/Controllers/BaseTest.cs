using System;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;

namespace CashFlow.Tests.Controllers
{
    public class BaseTest
    {
        public IServiceProvider InstanciateHttpContext(string userName)
        {
            var httpRequest = new HttpRequest("", "http://tempuri.org/", "");
            var stringWriter = new StringWriter();
            var httpResponse = new HttpResponse(stringWriter);
            var httpContext = new HttpContext(httpRequest, httpResponse);

            var sessionContainer =
                new HttpSessionStateContainer(
                    "id", new SessionStateItemCollection(),
                    new HttpStaticObjectsCollection(), 10, true,
                    HttpCookieMode.AutoDetect,
                    SessionStateMode.InProc, false
                );

            httpContext.Items["AspSession"] =
                typeof(HttpSessionState).GetConstructor(
                    BindingFlags.NonPublic | BindingFlags.Instance,
                    null, CallingConventions.Standard,
                    new[] { typeof(HttpSessionStateContainer) },
                    null
               ).Invoke(new object[] { sessionContainer });

            HttpContext.Current = httpContext;

            // User is logged in
            HttpContext.Current.User = new GenericPrincipal(
                new GenericIdentity(userName),
                new string[0]
            );

            //// User is logged out
            //HttpContext.Current.User = new GenericPrincipal(
            //    new GenericIdentity(String.Empty),
            //    new string[0]
            //);
            
            return httpContext;
        }
    }
}