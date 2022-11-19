namespace ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;


public record DesktopDTO(Guid Id, string Name, string Model, string HardDisk,
                                  string OS, string Processor, string Ram,
                                  string Graphics, string Price, string DesktopPCDescription, double Rating);

