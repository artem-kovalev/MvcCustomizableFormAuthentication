namespace MvcCustomizableFormAuthentication.Authorize
{
    public interface IAuthorizeService<in TAccount>
    {
        void SignIn(TAccount account, bool createPersistentCookie);
        void SignOut();
    }
}

