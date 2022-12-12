namespace ComputerTechAPI_DtoAndFeatures.RequestFeatures.TechParams.PCComponentsTechParams;

public class GPUParams : RequestQueryParameters
{
    public double MinRating { get; set; }
    public double MaxRating { get; set; } = double.MaxValue;
    public bool RatingRange => MaxRating > MinRating;
    public string? SearchTerm { get; set; }
}