namespace MvcCustomizableFormAuthentication
{
    using System;
    using System.Web.Mvc;

    public abstract class AbstractController<TIdenty, TAccount, TRole> : Controller
        where TIdenty : AbstractIdentity<TAccount, TRole>
    {
        protected AbstractController()
        {
            _user = new Lazy<TIdenty>(() => HttpContext.User.Identity as TIdenty);
        }

        private readonly Lazy<TIdenty> _user;


        protected TIdenty CurrentUser { get { return _user.Value; } }
    }
}