namespace ComputerTechAPI_Entities.ErrorExceptions;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message)
    : base(message)
    { }
}

