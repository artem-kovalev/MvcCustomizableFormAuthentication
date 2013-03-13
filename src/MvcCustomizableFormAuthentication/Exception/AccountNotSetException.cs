namespace MvcCustomizableFormAuthentication.Exception
{
    using System;

    public class AccountNotSetException : Exception
    {
        public AccountNotSetException()
            : base("Account not seted to Identity")
        {
            
        }
    }
}