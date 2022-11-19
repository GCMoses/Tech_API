namespace ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;

public sealed class GamingKeyboardNotFoundException : NotFoundException
{
    public GamingKeyboardNotFoundException(Guid gamingKeyboardId) : base($"The gamingKeyboard with id: {gamingKeyboardId} doesn't exist in the database.")
    {
    }
}

