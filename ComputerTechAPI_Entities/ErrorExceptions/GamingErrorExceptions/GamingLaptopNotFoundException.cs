namespace ComputerTechAPI_Entities.ErrorExceptions.GamingErrorExceptions;

public sealed class GamingLaptopNotFoundException : NotFoundException
{
    public GamingLaptopNotFoundException(Guid gamingLaptopId) : base($"The gamingLaptop with id: {gamingLaptopId} doesn't exist in the database.")
    {
    }
}

