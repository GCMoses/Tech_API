namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record HDDUpdateDTO(string Name, string StorageCapacity, string Interface,
                           string CacheSize, string FormFactor, string Price, double Rating);

