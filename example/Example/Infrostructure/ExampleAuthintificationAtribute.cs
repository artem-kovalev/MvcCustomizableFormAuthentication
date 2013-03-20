namespace Example.Infrostructure
{
    using DomainModel;
    using MvcCustomizableFormAuthentication;
    using System.Linq;

    public class ExampleAuthintificationAtribute : AbstractAutintificateAttribute
    {

        private readonly ExampleRuleFactory _ruleFactory = new ExampleRuleFactory();
 
        public ExampleAuthintificationAtribute(params Role[] allowedRole) : base(allowedRole.Cast<object>())
        {
            AddRule(_ruleFactory.Create((account,roles) => roles.Intersect(account.Roles).Any()));
            AddRule(_ruleFactory.Create((account, roles) => account.Name == "Admin"));
        }
    }
}