namespace ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;


public record DesktopUpdateDTO(string Name, string Model, string HardDisk,
                               string OS, string Processor, string Ram,
                               string Graphics, string Price, string DesktopPCDescription, double Rating);

