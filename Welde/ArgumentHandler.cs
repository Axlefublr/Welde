namespace Welde;

internal static class ArgumentHandler
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
			case "inc":
			case "increment":
				cm.Increment();
				cm.Show();
				break;
			case "reset":
				cm.Reset();
				cm.Show();
				break;
			case "set":
				cm.Set(args[1]);
				break;
		}
	}

	internal static int ParseStringIntoInt(string text)
	{
		bool success = int.TryParse(text, out int number);
		if (!success)
		{
			throw new FormatException("Can't convert string into int");
		}
		return number;
	}

}