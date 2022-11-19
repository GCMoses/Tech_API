namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class SSDNotFoundException : NotFoundException
{
    public SSDNotFoundException(Guid ssdId) : base($"The ssd with id: {ssdId} doesn't exist in the database.")
    {
    }
}

