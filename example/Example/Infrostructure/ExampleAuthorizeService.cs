namespace Example.Infrostructure
{
    using DomainModel;
    using MvcCustomizableFormAuthentication.Authorize;

    public class ExampleAuthorizeService : AbstractAuthorizeService<ExampleIdentity, Account, Role>
    {  
    }
}