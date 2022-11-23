namespace ComputerTechAPI_Entities.ErrorExceptions;

public abstract class BadRequestException : Exception
{
    protected BadRequestException(string message)
    : base(message)
    {
    }
}