using System.Windows;

namespace BATS.Models;

internal class PlaceInfo
{
    public string CountryName { get; set; }
    public Point Location { get; set; }
    public IEnumerable<ConfirmedCount> Counts { get; set; } = new List<ConfirmedCount>();
}

internal class ConfirmedCount
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
}

internal class CountryInfo : PlaceInfo
{
    public IEnumerable<ProvinceInfo> Provinces { get; set; } = new List<ProvinceInfo>();
}

internal class ProvinceInfo : PlaceInfo
{
}

internal struct DataPoint
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }
}
