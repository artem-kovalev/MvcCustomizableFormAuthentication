namespace MvcCustomizableFormAuthentication
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Security;

    public abstract class AbstractAutentificationModule<TIdenty, TAccount, TRole> : IHttpModule
        where TIdenty : AbstractIdentity<TAccount, TRole>
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnAuthenticateRequest;
        }

        private static void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;

            var context = application.Context;

            if (context.User != null && context.User.Identity.IsAuthenticated)
                return;

            var cookieName = FormsAuthentication.FormsCookieName;

            var cookie = application.Request.Cookies[cookieName.ToUpper()];

            if (cookie == null)
                return;
            try
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                var identity = AbstractIdentity<TAccount, TRole>.Deserialize<TIdenty>(ticket.UserData);
                var principal = new GenericPrincipal(identity, identity.Role);
                context.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch
            {}
        }

        public void Dispose()
        {}
    }
}