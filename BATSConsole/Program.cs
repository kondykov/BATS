namespace BATSConsole;

internal static class Program
{
    private const string CvsUrl = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
    static void Main(string[] args)
    {
        var client = new HttpClient();
        
        var response = client.GetAsync(CvsUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        
        Console.WriteLine("Hello, World!");
    }
}