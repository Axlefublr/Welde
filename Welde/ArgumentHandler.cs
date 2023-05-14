namespace Welde;

internal class ArgumentHandler
{

	internal static bool ValidateArguments(string[] args)
	{
		if (args.Length <= 0)
		{
			return false;
		}
		return true;
	}
}