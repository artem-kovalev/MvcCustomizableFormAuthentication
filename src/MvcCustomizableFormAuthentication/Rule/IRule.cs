namespace MvcCustomizableFormAuthentication.Rule
{
	using System.Security.Principal;
	using System.Collections.Generic;
	public interface IRule
	{
		bool Check(IIdentity user, IEnumerable<object> allowedRole);
	}
}

