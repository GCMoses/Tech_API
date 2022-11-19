namespace ComputerTechAPI_Entities.ErrorExceptions.PCErrorExceptions;

public sealed class LaptopNotFoundException : NotFoundException
{
    public LaptopNotFoundException(Guid laptopId) : base($"The laptop with id: {laptopId} doesn't exist in the database.")
    {
    }
}

