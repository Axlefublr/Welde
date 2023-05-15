using System.Text;

namespace Welde;

public class CounterManager
{

	public CounterManager()
	{
		EnsureCounterFileExists();
	}

	private readonly string counterFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "counter.txt");

	public void Increment()
	{
		int counter = Read();
		counter++;
		Write(counter);
	}

	public void Show()
	{
		string message = "Current count is: ";
		message += GetSticks();
		Console.WriteLine(message);
	}

	public void Reset() => Write(0);

	public void Set(string newCounter)
	{
		int number = ArgumentHandler.ParseStringIntoInt(newCounter);
		Set(number);
	}

	public void Eat()
	{
		int currentCount = Read();
		currentCount -= Settings.DecrementEveryDay;
		Set(currentCount);
	}

	private void Set(int newCounter) => Write(newCounter);

	private int Read()
	{
		string text = File.ReadAllText(counterFile);
		int result = ArgumentHandler.ParseStringIntoInt(text);
		return result;
	}

	private void Write(int currentCount) => File.WriteAllText(counterFile, currentCount.ToString());

	private string GetSticks()
	{
		int amount = Read();
		string sticks = "0";
		if (amount != 0)
		{
			sticks = new(Settings.ShowCountChr, Math.Abs(amount));
		}
		if (amount < 0)
		{
			sticks = "-" + sticks;
		}
		return sticks;
	}

	private void EnsureCounterFileExists()
	{
		if (!File.Exists(counterFile))
		{
			File.WriteAllText(counterFile, "0");
		}
	}
}