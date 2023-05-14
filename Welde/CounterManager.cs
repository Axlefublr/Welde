namespace Welde;

public class CounterManager
{

	private readonly string counterFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "counter.txt");

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

	private void Write(int currentCount)
	{
		File.WriteAllText(counterFile, currentCount.ToString());
	}
}