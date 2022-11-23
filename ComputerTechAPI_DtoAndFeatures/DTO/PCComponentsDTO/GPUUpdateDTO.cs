namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record GPUUpdateDTO(string Name, string Bus, string GPUClock,
                           string VRAM, string Interface, string CoolingType,
                           string DXVersion, string Price, double Rating);

