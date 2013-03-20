namespace MvcCustomizableFormAuthentication.Test.MockObject
{
    public class MockIdentity : AbstractIdentity<MockAccount, Role>
    {
        protected override long GetId(MockAccount account)
        {
            return 1;
        }

        protected override string GetName(MockAccount account)
        {
            return "Name";
        }

        protected override Role[] GetRole(MockAccount account)
        {
            return new[] { MockObject.Role.Admin   };
        }
    }
}