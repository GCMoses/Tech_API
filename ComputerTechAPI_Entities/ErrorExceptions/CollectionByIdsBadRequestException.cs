namespace ComputerTechAPI_Entities.ErrorExceptions;
public sealed class CollectionByIdsBadRequestException : BadRequestException
{
    public CollectionByIdsBadRequestException()
    : base("Collection count mismatch comparing to ids.")
    {
    }
}