namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record HDDDTO(Guid Id, string Name, string StorageCapacity, string Interface,
                        string CacheSize, string FormFactor, string Price, double Rating);

