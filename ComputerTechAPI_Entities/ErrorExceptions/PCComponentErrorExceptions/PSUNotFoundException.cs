namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class PSUNotFoundException : NotFoundException
{
    public PSUNotFoundException(Guid psuId) : base($"The psu with id: {psuId} doesn't exist in the database.")
    {
    }
}

