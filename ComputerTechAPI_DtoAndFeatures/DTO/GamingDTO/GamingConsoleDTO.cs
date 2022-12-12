namespace ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;


public record GamingConsoleDTO(Guid Id, string Name, string ImgURL, string Model,
                                        string DiskDrive, string ResolutionAndFrameRate, string HardDisk, string Processor,
                                        string Graphics, string RAM, string Controller, string Price, string ShortDescription, 
                                        double Rating);

