namespace Example.Infrostructure
{
    using DomainModel;
    using MvcCustomizableFormAuthentication;
    using System.Linq;

    public class ExampleAuthintificationAtribute : AbstractAutintificateAttribute
    {
        private readonly ExampleRuleFactory _ruleFactory = new ExampleRuleFactory();
 
        public ExampleAuthintificationAtribute(params Role[] allowedRole) : base(allowedRole.Any())
        {
            // Only users with allowed roles can view this page
            AddRule(_ruleFactory.Create(account => allowedRole.Intersect(account.Roles).Any()));

            //Admin having all the access level
            AddRule(_ruleFactory.Create(account => account.Roles.Any(c=>c == Role.Admin)));
        }
    }
}