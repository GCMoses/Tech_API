namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class CPUCoolerNotFoundException : NotFoundException
{
    public CPUCoolerNotFoundException(Guid cpuCoolerId) : base($"The cpuCooler with id: {cpuCoolerId} doesn't exist in the database.")
    {
    }
}

