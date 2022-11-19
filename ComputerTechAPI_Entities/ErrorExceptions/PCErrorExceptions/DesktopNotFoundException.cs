namespace ComputerTechAPI_Entities.ErrorExceptions.PCErrorExceptions;

public sealed class DesktopNotFoundException : NotFoundException
{
    public DesktopNotFoundException(Guid desktopId) : base($"The desktop with id: {desktopId} doesn't exist in the database.")
    {
    }
}

