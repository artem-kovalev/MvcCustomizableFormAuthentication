namespace MvcCustomizableFormAuthentication.Rule
{
	using System.Security.Principal;

	public interface IRule
	{
		bool Check(IIdentity user);
	}
}

