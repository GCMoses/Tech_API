﻿namespace ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;


public record GamingLaptopDTO(Guid Id, string Name, string ImgURL, string DisplaySize,
                                       string DisplayResolution, string CoolingSystem, string HardDisk, string Processor,
                                       string Graphics, string Ram, string OS, string Weight, string Price, 
                                       string GamingLaptopDescription, double Rating);

