namespace MvcCustomizableFormAuthentication.Rule
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Principal;

	internal class Rule<TIdentity, TAccount, TRole> : IRule 
		where TIdentity : AbstractIdentity<TAccount, TRole>
	{

		public Rule(Func<TIdentity, IEnumerable<TRole>, bool> check)
		{
			if (check == null) 
				throw new ArgumentNullException("check");

			_check = check;
		}

		private readonly Func<TIdentity, IEnumerable<TRole>, bool> _check;

		public bool Check (IIdentity user, IEnumerable<object> allowedRoles)
		{
			if (allowedRoles == null)
                throw new ArgumentNullException("allowedRoles");


			IEnumerable<TRole> castAllowedRoles = allowedRoles.Cast<TRole> ();
			return _check((TIdentity) user, castAllowedRoles);
		}
	}
}

