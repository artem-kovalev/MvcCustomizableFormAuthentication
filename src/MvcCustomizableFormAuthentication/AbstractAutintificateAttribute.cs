namespace MvcCustomizableFormAuthentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public abstract class AbstractAutintificateAttribute : AuthorizeAttribute
    {
        protected readonly IEnumerable<object> AllowedRole;

        protected AbstractAutintificateAttribute(IEnumerable<object> allowedRole)
        {
            if (allowedRole == null)
                throw new ArgumentNullException("allowedRole");
            AllowedRole = allowedRole;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (httpContext.User == null)
                return false;

            return AllowedRole.Any() 
                ? AllowedRole.Any(x => httpContext.User.IsInRole(x.ToString())) 
                : httpContext.Request.IsAuthenticated;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var context = filterContext.HttpContext;

            var appPath = context.Request.ApplicationPath == "/"
                                ? string.Empty
                                : context.Request.ApplicationPath;

            var loginUrl = FormsAuthentication.LoginUrl;
            var path = HttpUtility.UrlEncode(context.Request.Url.PathAndQuery);

            var url = String.Format("{0}{1}?ReturnUrl={2}", appPath, loginUrl, path);

            if (!filterContext.IsChildAction)
                filterContext.Result = new RedirectResult(url);
        }
    }
}