namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record CPUDTO(Guid Id, string Name, string BaseClock, string BoostClock,
                        string HyperThreading, string CPUCore, string CpuTDP,
                        string Cache, string Socket, string Price, double Rating);

