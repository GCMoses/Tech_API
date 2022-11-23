namespace ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;


public record GamingDesktopUpdateDTO(string Name, string ImgURL, string GamingCase,
                                        string CoolingSystem, string OS, string HardDisk, string Processor,
                                        string Graphics, string Ram, string Controller, string Price,
                                        string GamingPCDescription, double Rating);

