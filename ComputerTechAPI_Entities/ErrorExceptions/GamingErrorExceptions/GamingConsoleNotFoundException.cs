namespace ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;

public sealed class GamingConsoleNotFoundException : NotFoundException
{
    public GamingConsoleNotFoundException(Guid gamingConsoleId) : base($"The gamingConsole with id: {gamingConsoleId} doesn't exist in the database.")
    {
    }
}

