namespace ComputerTechAPI_Entities.ErrorExceptions;

public sealed class ProductCollectionBadRequest : BadRequestException
{
    public ProductCollectionBadRequest()
    : base("Product collection sent from a client is null.")
    {
    }
}
