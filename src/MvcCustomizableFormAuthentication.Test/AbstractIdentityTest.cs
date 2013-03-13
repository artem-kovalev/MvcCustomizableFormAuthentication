namespace MvcCustomizableFormAuthentication.Test
{
    using Exception;
    using MockObject;
    using Xunit;

    public class AbstractIdentityTest
    {
    
        private readonly MockAccount account = new MockAccount();

        [Fact]
        public void SerializeTest()
        {
            var identity = new MockIdentity();
            identity.SetAccount(account);

            var serializedIdentity = identity.Serialize();

            Assert.False(string.IsNullOrEmpty(serializedIdentity));

        }


        [Fact]
        public void IfNotSetAccountThenThrowException()
        {
            var identity = new MockIdentity();

            Assert.Throws<AccountNotSetException>(() => identity.Serialize());
        }

        [Fact]
        public void DesirializeTest()
        {
             var identity = new MockIdentity();
            identity.SetAccount(account);

            var serializedIdentity = identity.Serialize();
            var desirializeIdenty = MockIdentity.Deserialize<MockIdentity>(serializedIdentity);
        
            Assert.False(identity == desirializeIdenty);

            Assert.Equal(identity.AuthenticationType, desirializeIdenty.AuthenticationType);
            Assert.Equal(identity.Id, desirializeIdenty.Id);
            Assert.Equal(identity.AuthenticationType, desirializeIdenty.AuthenticationType);
            Assert.Equal(identity.Name, desirializeIdenty.Name);
            Assert.Equal(identity.Role, desirializeIdenty.Role);
        }
    }
}