using System.Globalization;

namespace BATSConsole;

internal static class Program
{
    private const string CsvUrl =
        @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

    private static async Task<Stream> GetDataStream()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(CsvUrl, HttpCompletionOption.ResponseHeadersRead);
        return await response.Content.ReadAsStreamAsync();
    }

    private static IEnumerable<string> ReadLines()
    {
        using var dataStream = GetDataStream().Result;
        using var streamReader = new StreamReader(dataStream);

        while (!streamReader.EndOfStream)
        {
            var line = streamReader.ReadLineAsync().Result;
            yield return line.Replace("Korea,", "Korea -")
                .Replace("Bonaire,", "Bonaire -")
                .Replace("Helena,", "Helena -");
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

    private static IEnumerable<(string Country, string Province, int[] Counts)> GetCountries()
    {
        var lines = ReadLines()
            .Skip(1)
            .Select(line => line.Split(','));

        foreach (var row in lines)
        {
            var province = row[0].Trim();
            var country = row[1].Trim(' ', '"');
            var counts = row.Skip(4).Select(int.Parse).ToArray();

            yield return (country, province, counts);
        }
    }

    private static void Main(string[] args)
    {
        /*var dates = GetDates();

        Console.WriteLine(string.Join("\r\n", dates));*/

        var russian = GetCountries().First(v => v.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(string.Join("\r\n", GetDates().Zip(russian.Counts, (date, count) => $"{date} - {count}")));

        // foreach (var dataLine in ReadLines()) Console.WriteLine(dataLine);
    }
}