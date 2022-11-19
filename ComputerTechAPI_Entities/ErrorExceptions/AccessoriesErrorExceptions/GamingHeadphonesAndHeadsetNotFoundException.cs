namespace ComputerTechAPI_Entities.ErrorExceptions.AccessoriesErrorExceptions;

public sealed class GamingHeadphonesAndHeadsetNotFoundException : NotFoundException
{
    public GamingHeadphonesAndHeadsetNotFoundException(Guid gamingHeadphonesAndHeadsetId) : base($"The gamingHeadphonesAndHeadset with id: {gamingHeadphonesAndHeadsetId} doesn't exist in the database.")
    {
    }
}

