namespace ComputerTechAPI_Entities.ErrorExceptions;

public sealed class RefreshTokenBadRequest : BadRequestException
{
    public RefreshTokenBadRequest()
    : base("Invalid client request. The token is invalid.")
    {
    }
}

