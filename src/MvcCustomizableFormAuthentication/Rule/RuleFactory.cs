using System;
using MvcCustomizableFormAuthentication.Rule;

namespace MvcCustomizableFormAuthentication
{
	public class RuleFactory<TIdentity, TAccount, TRole>
		where TIdentity : AbstractIdentity<TAccount, TRole>
	{
		public IRule Create(Func<TIdentity, IEnumerable<TRole>, bool> rule) 
		{
			return new Rule<TIdentity, TAccount, TRole> (rule);
		}

	}
}

