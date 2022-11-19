namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class MotherboardNotFoundException : NotFoundException
{
    public MotherboardNotFoundException(Guid motherboardId) : base($"The motherboard with id: {motherboardId} doesn't exist in the database.")
    {
    }
}

