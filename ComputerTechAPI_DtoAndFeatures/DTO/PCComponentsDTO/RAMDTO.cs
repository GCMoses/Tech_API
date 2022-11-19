namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record RAMDTO(Guid Id, string Name, string RamCapacity, string RAMSpeed,
                        string RAMType, string Price, double Rating);

