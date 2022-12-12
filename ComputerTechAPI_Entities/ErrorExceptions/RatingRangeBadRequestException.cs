namespace ComputerTechAPI_Entities.ErrorExceptions;

public sealed class RatingRangeBadRequestException : BadRequestException 
{
    public RatingRangeBadRequestException()
       : base("Max rating can't be less than min rating.")
    {
    }
}
