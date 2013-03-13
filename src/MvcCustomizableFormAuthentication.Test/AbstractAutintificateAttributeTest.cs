namespace MvcCustomizableFormAuthentication.Test
{
    using System.Security.Principal;
    using System.Web;
    using System.Web.Mvc;
    using MockObject;
    using Moq;
    using Xunit;

    public class AbstractAutintificateAttributeTest
    {
        private readonly MockIdentity identity = new MockIdentity();

        [Fact]
        public void t()
        {
            var container = new AutoMockContainer(factory: new MockRepository(MockBehavior.Strict));
            var a = container.GetMock<AuthorizationContext>().Object;

          /*  Mock<AuthorizationContext> authorizationContext = new <AuthorizationContext>();
            Mock<HttpContextBase> httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(c => c.User).Returns(new GenericPrincipal(identity, identity.Role));

            authorizationContext.SetReturnsDefault();
            //authorizationContext.Setup(c => c.HttpContext).Returns(()=>httpContext.Object);
           
            MockAutintificateAttribute attribute = new MockAutintificateAttribute(Role.Admin);

            attribute.OnAuthorization(authorizationContext.Object);*/
        }
    }
}