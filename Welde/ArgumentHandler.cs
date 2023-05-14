namespace Welde;

internal class ArgumentHandler
{

	internal static bool ValidateArguments(string[] args)
	{
		if (args.Length < 1)
		{
			return false;
		}
		return true;
	}

	internal static void CallCommand(CounterManager cm, string[] args)
	{
		string commandName = args[0];
		switch (commandName)
		{
			case "show":
				cm.Show();
				break;
		}
	}
}