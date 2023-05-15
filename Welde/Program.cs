﻿namespace Welde;

internal class Program
{
	private static int Main(string[] args)
	{
		bool areValid = ArgumentHandler.ValidateArguments(args);
		if (!areValid)
		{
			return 666;
		}
		CounterManager cm = new();
		Eater yummy = new(cm);
		yummy.CheckEat();
		ArgumentHandler.CallCommand(cm, args);

		return 0;
	}
}