namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class CPUNotFoundException : NotFoundException
{
    public CPUNotFoundException(Guid cpuId) : base($"The cpu with id: {cpuId} doesn't exist in the database.")
    {
    }
}

