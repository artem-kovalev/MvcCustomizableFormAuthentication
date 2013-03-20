namespace Example.Infrostructure
{
    using DomainModel;
    using MvcCustomizableFormAuthentication;

    public class ExampleIdentity : AbstractIdentity<Account, Role>
    {

        public string Email { get; set; }

        protected override long GetId(Account account)
        {
            return account.Id;
        }

        protected override string GetName(Account account)
        {
            return account.Login;
        }

        protected override Role[] GetRole(Account account)
        {
            return new Role[]{ account.Role };
        }

        /// <summary>
        /// This override method
        /// </summary>
        /// <param name="account"></param>
        protected override void InitializeMoreFields(Account account)
        {
            Email = account.Email;
        }
    }
}