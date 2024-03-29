﻿namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record MotherboardDTO(Guid Id, string Name, string MoboCPU, string Chipset,
                        string MoboMaxMemory, string PCIExpress, string MoboUSBPorts,
                        string MoboConnectors, string Price, double Rating);

