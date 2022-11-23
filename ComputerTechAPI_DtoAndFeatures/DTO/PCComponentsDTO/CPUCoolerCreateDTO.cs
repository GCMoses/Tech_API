﻿namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record CPUCoolerCreateDTO(string Name, string BuiltInFan, string Radiator,
                                 string MaxFanNoiseLevel, string PWMSupport, string MaxAirflow,
                                 string NumberOfFans, string SocketSupport, string Price, double Rating);
