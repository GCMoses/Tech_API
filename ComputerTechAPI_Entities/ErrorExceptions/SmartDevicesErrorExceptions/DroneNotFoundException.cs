namespace ComputerTechAPI_Entities.ErrorExceptions.SmartDevicesErrorExceptions;

public sealed class DroneNotFoundException : NotFoundException
{
    public DroneNotFoundException(Guid droneId) : base($"The drone with id: {droneId} doesn't exist in the database.")
    {
    }
}

