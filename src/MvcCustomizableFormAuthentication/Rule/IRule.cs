namespace MvcCustomizableFormAuthentication.Rule
{
	using System;
	using System.Security.Principal;
	using System.Collections.Generic;


	internal interface IRule
	{
		bool Check(IIdentity user, IEnumerable<object> allowedRole);
	}
}

