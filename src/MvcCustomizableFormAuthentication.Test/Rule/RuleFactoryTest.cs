namespace MvcCustomizableFormAuthentication.Test.Rule
{
    using System;
    using MockObject;
    using MvcCustomizableFormAuthentication.Rule;
    using Xunit;

    public class RuleFactoryTest
    {
        private readonly RuleFactory<MockIdentity, MockAccount, Role> _ruleFactory = new RuleFactory<MockIdentity, MockAccount, Role>();

        [Fact]
        public void IfArgumentToCreateFunctionNullReferenceThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => _ruleFactory.Create(null));
        }
    }
}