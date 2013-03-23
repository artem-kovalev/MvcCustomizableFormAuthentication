namespace MvcCustomizableFormAuthentication.Rule
{
	using System;
	using System.Security.Principal;

	internal class Rule<TIdentity, TAccount, TRole> : IRule 
		where TIdentity : AbstractIdentity<TAccount, TRole>
	{
        private readonly Func<TIdentity, bool> _check;

		public Rule(Func<TIdentity, bool> check)
		{
			if (check == null) 
				throw new ArgumentNullException("check");

			_check = check;
		}

		public bool Check (IIdentity user)
		{
			return _check((TIdentity) user);
		}
	}
}

