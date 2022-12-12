using static System.Net.Mime.MediaTypeNames;

namespace ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.AccessoriesTechParams;

public class GamingHeadphonesAndHeadsetParams : RequestQueryParameters
{

   // public GamingHeadphonesAndHeadsetParams() => OrderBy = "name";
    public double MinRating { get; set; }
    public double MaxRating { get; set; } = double.MaxValue;
    public bool RatingRange => MaxRating > MinRating;
    public string? SearchTerm { get; set; }
}
