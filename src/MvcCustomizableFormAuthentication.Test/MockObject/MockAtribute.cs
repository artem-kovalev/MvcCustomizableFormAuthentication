namespace MvcCustomizableFormAuthentication.Test.MockObject
{
    using System.Linq;

    public class MockAutintificateAttribute : AbstractAutintificateAttribute
    {
        public MockAutintificateAttribute(params Role[] allowedRole) 
            : base(allowedRole.Any())
        {
        }
    }
}