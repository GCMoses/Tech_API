namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class RAMNotFoundException : NotFoundException
{
    public RAMNotFoundException(Guid ramId) : base($"The ram with id: {ramId} doesn't exist in the database.")
    {
    }
}

