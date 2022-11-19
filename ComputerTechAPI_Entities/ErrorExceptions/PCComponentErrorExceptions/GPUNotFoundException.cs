namespace ComputerTechAPI_Entities.ErrorExceptions.PCComponentErrorExceptions;

public sealed class GPUNotFoundException : NotFoundException
{
    public GPUNotFoundException(Guid gpuId) : base($"The gpu with id: {gpuId} doesn't exist in the database.")
    {
    }
}

