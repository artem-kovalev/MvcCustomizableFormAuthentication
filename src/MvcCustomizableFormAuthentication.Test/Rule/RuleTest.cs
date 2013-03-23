namespace MvcCustomizableFormAuthentication.Test.Rule
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using MockObject;
    using Moq;
    using MvcCustomizableFormAuthentication.Rule;
    using Xunit;

    public class RuleTest
    {
        private readonly RuleFactory<MockIdentity, MockAccount, Role> _ruleFactory = new RuleFactory<MockIdentity, MockAccount, Role>();
        private readonly MockIdentity _identity;
            
        public RuleTest()
        {
            _identity = new MockIdentity();
            _identity.SetAccount(null);
        }

        [Fact]
        public void CheckRuleTrue()
        {
            var ruleTrue = _ruleFactory.Create(c => c.Id == 1);
            Assert.True(ruleTrue.Check(_identity));
        }

        [Fact]
        public void CheckRuleFalse()
        {
            var ruleTrue = _ruleFactory.Create(c => c.Id == 100);
            Assert.False(ruleTrue.Check(_identity));
        }

        [Fact]
        public void IfArgumentIdentitytOtherTypeThenThrowsInvalidCastException()
        {
            var otherIdenty = new Mock<IIdentity>().Object;
            var ruleTrue = _ruleFactory.Create(c => c.Id > -1);
            Assert.Throws<InvalidCastException>(() => ruleTrue.Check(otherIdenty));

        }

        [Fact]
        public void IfArgumentAllowedRolesNullReferenceThenThrowNullPointerException()
        {
            var ruleTrue = _ruleFactory.Create(c => c.Id > -1);
            Assert.Throws<ArgumentNullException>(() => ruleTrue.Check(_identity));
        }

    }
}
