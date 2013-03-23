namespace MvcCustomizableFormAuthentication.Rule
{
    using System;

    public class RuleFactory<TIdentity, TAccount, TRole>
		where TIdentity : AbstractIdentity<TAccount, TRole>
	{
		public IRule Create(Func<TIdentity, bool> rule) 
		{
			return new Rule<TIdentity, TAccount, TRole> (rule);
		}

	}
}

