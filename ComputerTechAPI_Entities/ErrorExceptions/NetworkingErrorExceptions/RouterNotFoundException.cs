namespace ComputerTechAPI_Entities.ErrorExceptions.NetworkingErrorExceptions;

public sealed class RouterNotFoundException : NotFoundException
{
    public RouterNotFoundException(Guid routerId) : base($"The router with id: {routerId} doesn't exist in the database.")
    {
    }
}

