namespace MvcCustomizableFormAuthentication.Authorize
{
    using System;
    using System.Security.Principal;
    using System.Web;
    using System.Web.Security;

    public abstract class AbstractAuthorizeService<TIdentity, TAccount, TRole> : IAuthorizeService<TAccount>
       where TIdentity : AbstractIdentity<TAccount, TRole>, new()
    {
        private const int TICKET_VERSION = 1;
        private const int EXPIRATION_MINUTE = 60;

        public void SignIn(TAccount account, bool createPersistentCookie)
        {
            var accountIdentity = CreateIdentity(account);

            var authTicket = new FormsAuthenticationTicket(TICKET_VERSION,
                                                            accountIdentity.Name,
                                                            DateTime.Now,
                                                            DateTime.Now.AddMinutes(EXPIRATION_MINUTE),
                                                            createPersistentCookie,
                                                            accountIdentity.Serialize());

            CreateCookie(authTicket);

            HttpContext.Current.User = new GenericPrincipal(accountIdentity, accountIdentity.Role);
        }

        private TIdentity CreateIdentity(TAccount account)
        {
            var accountIdentity = new TIdentity();
            accountIdentity.SetAccount(account);
            return accountIdentity;
        }

        private void CreateCookie(FormsAuthenticationTicket ticket)
        {   
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName,  FormsAuthentication.Encrypt(ticket))
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
            };

            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}

