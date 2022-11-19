namespace ComputerTechAPI_Entities.ErrorExceptions;

public sealed class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException(Guid productId): base($"The product with id: {productId} doesn't exist in the database.")
    {
    }
}

