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
		Console.Write();
	}

	public void Reset() => Write(0);

	public void Set(int newCounter) => Write(newCounter);

	private int Read()
	{
		string text = File.ReadAllText(counterFile);
		bool success = int.TryParse(text, out int result);
		if (!success)
		{
			throw new FormatException("Counter file isn't fully a integer");
		}
		return result;
	}

	private void Write(int currentCount) => File.WriteAllText(counterFile, currentCount.ToString());

	private string GetSticks()
	{
		int amount = Read();
		string message = "Current count is: ";
		message += new string(Settings.ShowCountChr, amount);
		return message;
	}

	private void EnsureCounterFileExists()
	{
		if (!File.Exists(counterFile))
		{
			File.WriteAllText(counterFile, "0");
		}
	}
}