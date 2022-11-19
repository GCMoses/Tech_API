namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class HDDNotFoundException : NotFoundException
{
    public HDDNotFoundException(Guid hddId) : base($"The hdd with id: {hddId} doesn't exist in the database.")
    {
    }
}

