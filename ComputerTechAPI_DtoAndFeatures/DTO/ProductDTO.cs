namespace ComputerTechAPI_DtoAndFeatures.DTO;


[Serializable]
public record ProductDTO
{
    public Guid Id { get; init; }
    public string? Category { get; init; }
}

