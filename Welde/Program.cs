namespace Welde;

internal class Program
{
	private static int Main(string[] args)
	{
		bool areValid = ArgumentHandler.ValidateArguments(args);
		if (!areValid)
		{
			return 666;
		}
		return 0;
	}
}