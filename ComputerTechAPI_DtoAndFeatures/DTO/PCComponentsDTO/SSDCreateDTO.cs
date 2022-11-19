namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record SSDCreateDTO(string Name, string StorageCapacity, string Interface,
                           string ReadWriteSpeed, string CacheMemory, string FormFactor,
                           string Price, double Rating);

