namespace ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.SmartDecivesTechParams;

public class DroneParams : RequestQueryParameters
{
    public double MinRating { get; set; }
    public double MaxRating { get; set; } = double.MaxValue;
    public bool RatingRange => MaxRating > MinRating;
    public string? SearchTerm { get; set; }
}