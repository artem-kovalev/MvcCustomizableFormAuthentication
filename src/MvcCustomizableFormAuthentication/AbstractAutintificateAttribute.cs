namespace MvcCustomizableFormAuthentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
	using MvcCustomizableFormAuthentication.Rule;
	using System.Security.Principal;

    public abstract class AbstractAutintificateAttribute : AuthorizeAttribute
    {
        protected readonly IEnumerable<object> AllowedRole;
		private readonly ICollection<IRule> _rules = new List<IRule> ();

        protected AbstractAutintificateAttribute(IEnumerable<object> allowedRole)
        {
            if (allowedRole == null)
                throw new ArgumentNullException("allowedRole");

            AllowedRole = allowedRole;
        }

		protected void AddRule(IRule rule) 
		{
			if (rule == null)
				throw new ArgumentNullException ("rule");

			_rules.Add (rule);
		}

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (httpContext.User == null)
                return false;

			if (AllowedRole.Any () && _rules.Any ()) 
			{
				IIdentity user = httpContext.User.Identity;
				return _rules.Any(rule => rule.Check(user, AllowedRole));
			}

			return httpContext.Request.IsAuthenticated;
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