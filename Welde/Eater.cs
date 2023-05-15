using System.Globalization;

namespace Welde;

internal class Eater
{

	private readonly string dateFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "date.txt");

	private void EnsureDateFileExists()
	{
		if (!File.Exists(dateFile))
		{
			File.WriteAllText(dateFile, GetDateNowString());
		}
	}

	private string GetDateNowString() => DateTime.Now.ToString("yyyy.MM.dd");

	private DateTime ParseDateFileIntoDateTime()
	{
		bool success = DateTime.TryParseExact(Read(), "yyyy.MM.dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
		if (!success)
		{
			throw new ArgumentException("Invalid date format. Use 'yyyy.MM.dd'");
		}
		return parsedDate;
	}

	private int GetDiffOfDays(DateTime prevDate)
	{
		TimeSpan difference = prevDate - DateTime.Now;
		int daysDifference = Math.Abs((int)difference.TotalDays);
		return daysDifference;
	}

	private string Read() => File.ReadAllText(dateFile);

}