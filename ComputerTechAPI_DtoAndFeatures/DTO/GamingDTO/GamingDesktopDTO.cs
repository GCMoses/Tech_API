﻿namespace ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;


public record GamingDesktopDTO(Guid Id, string Name, string ImgURL, string GamingCase,
                                        string CoolingSystem, string OS, string HardDisk, string Processor,
                                        string Graphics, string Ram, string PSU, string Price,
                                        string GamingPCDescription, double Rating);

