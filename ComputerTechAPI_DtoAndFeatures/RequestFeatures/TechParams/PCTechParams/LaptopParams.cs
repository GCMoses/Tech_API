namespace ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCTechParams;

public class LaptopParams : RequestQueryParameters
{
    public double MinRating { get; set; }
    public double MaxRating { get; set; } = double.MaxValue;
    public bool RatingRange => MaxRating > MinRating;
    public string? SearchTerm { get; set; }
}
