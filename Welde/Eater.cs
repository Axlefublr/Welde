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

	}
}