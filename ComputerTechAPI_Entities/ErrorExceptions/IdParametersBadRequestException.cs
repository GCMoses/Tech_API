namespace ComputerTechAPI_Entities.ErrorExceptions;

public sealed class IdParametersBadRequestException : BadRequestException
{
    public IdParametersBadRequestException()
    : base("Parameter ids is null")
    {
    }
}
