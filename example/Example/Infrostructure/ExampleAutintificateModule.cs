namespace Example.Infrostructure
{
    using DomainModel;
    using MvcCustomizableFormAuthentication;

    public class ExampleAutintificateModule : AbstractAutentificationModule<ExampleIdentity, Account, Role>
    {
    }
}