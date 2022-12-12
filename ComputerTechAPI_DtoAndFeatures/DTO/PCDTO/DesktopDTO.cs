namespace ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;


public record DesktopDTO(Guid Id, string Name, string Model, string Processor,
                                  string OS, string HardDisk, string Ram,
                                  string Graphics, string Price, string DesktopPCDescription, double Rating);

