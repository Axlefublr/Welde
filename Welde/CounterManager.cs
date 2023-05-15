using System.Drawing;
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
		Console.Write(message);
		ColorSticks();
		Console.WriteLine(GetSticks());
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
		return sticks;
	}

	private void ColorSticks()
	{
		int amount = Read();
		if (amount > 0)
		{
			Console.ForegroundColor = ConsoleColor.Green;
		}
		else if (amount < 0)
		{
			Console.ForegroundColor = ConsoleColor.Red;
		}
	}

	private void EnsureCounterFileExists()
	{
		if (!File.Exists(counterFile))
		{
			File.WriteAllText(counterFile, "0");
		}
	}
}