using System.Globalization;

namespace BATSConsole;

internal static class Program
{
    private const string CvsUrl =
        @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

    private static async Task<Stream> GetDataStream()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(CvsUrl, HttpCompletionOption.ResponseHeadersRead);
        return await response.Content.ReadAsStreamAsync();
    }

    public static IEnumerable<string> ReadLines()
    {
        using var dataStream = GetDataStream().Result;
        using var streamReader = new StreamReader(dataStream);

        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLineAsync().Result;
            yield return line;
        }
    }

    private static DateTime[] GetDates()
    {
        return ReadLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture)).ToArray();
    }
    

    private static void Main(string[] args)
    {
        var dates = GetDates();
        
        Console.WriteLine(string.Join("\r\n", dates));
        
        // foreach (var dataLine in ReadLines()) Console.WriteLine(dataLine);
    }
}