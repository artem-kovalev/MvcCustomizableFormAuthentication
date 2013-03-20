namespace Example.Infrostructure
{
    using DomainModel;
    using MvcCustomizableFormAuthentication;

    public abstract class ExampleController : AbstractController<ExampleIdentity, Account, Role>
    {
         
    }
}