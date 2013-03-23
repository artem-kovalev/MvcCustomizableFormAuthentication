namespace MvcCustomizableFormAuthentication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Rule;

    public abstract class AbstractAutintificateAttribute : AuthorizeAttribute
    {
		private readonly ICollection<IRule> _rules = new List<IRule> ();

        private readonly bool _isNotSimpleAuthentication;

        protected AbstractAutintificateAttribute(bool isNotSimpleAuthentication)
        {
            _isNotSimpleAuthentication = isNotSimpleAuthentication;
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

            if (httpContext.User == null || !httpContext.User.Identity.IsAuthenticated)
                return false;

            var isAuthorize = false;
            isAuthorize |= _rules.Any(rule => rule.Check(httpContext.User.Identity));
            isAuthorize |= httpContext.Request.IsAuthenticated && !_isNotSimpleAuthentication;
			return isAuthorize;
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