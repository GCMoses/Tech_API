namespace ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;

public sealed class GamingMouseNotFoundException : NotFoundException
{
    public GamingMouseNotFoundException(Guid gamingMouseId) : base($"The gamingMouse with id: {gamingMouseId} doesn't exist in the database.")
    {
    }
}

