namespace ComputerTechAPI_Entities.ErrorExceptions.SmartDevicesErrorExceptions;

public sealed class SmartPhoneNotFoundException : NotFoundException
{
    public SmartPhoneNotFoundException(Guid smartPhoneId) : base($"The smartPhone with id: {smartPhoneId} doesn't exist in the database.")
    {
    }
}

