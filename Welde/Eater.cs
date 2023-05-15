using System.Globalization;

namespace Welde;

internal class Eater
{

	private readonly CounterManager cm;

	internal Eater(CounterManager cm)
	{
		EnsureDateFileExists();
		this.cm = cm;
	}

	internal void CheckEat()
	{
		DateTime dt = ParseDateFileIntoDateTime();
		int daysDiff = GetDiffOfDays(dt);
		if (daysDiff <= 0)
		{
			return;
		}
		for (int i = 0; i < daysDiff; i++)
		{
			cm.Eat();
		}
	}

	private readonly string dateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "date.txt");

	private void EnsureDateFileExists()
	{
		if (!File.Exists(dateFile))
		{
			File.WriteAllText(dateFile, GetDateNowString());
		}
	}

	private static string GetDateNowString() => DateTime.Now.ToString("yyyy.MM.dd");

	private DateTime ParseDateFileIntoDateTime()
	{
		bool success = DateTime.TryParseExact(Read(), "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
		if (!success)
		{
			throw new ArgumentException("Invalid date format. Use 'yyyy.MM.dd'");
		}
		return parsedDate;
	}

	private static int GetDiffOfDays(DateTime prevDate)
	{
		TimeSpan difference = prevDate - DateTime.Now;
		int daysDifference = Math.Abs((int)difference.TotalDays);
		return daysDifference;
	}

	private string Read() => File.ReadAllText(dateFile).Trim();

}