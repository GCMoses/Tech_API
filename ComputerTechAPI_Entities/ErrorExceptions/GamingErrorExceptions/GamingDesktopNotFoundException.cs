namespace ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;

public sealed class GamingDesktopNotFoundException : NotFoundException
{
    public GamingDesktopNotFoundException(Guid gamingDesktopId) : base($"The gamingDesktop with id: {gamingDesktopId} doesn't exist in the database.")
    {
    }
}

