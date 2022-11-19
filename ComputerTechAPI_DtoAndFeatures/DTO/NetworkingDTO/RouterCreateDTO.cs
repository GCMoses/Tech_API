namespace ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;


public record RouterCreateDTO(string Name, string RAM, string TransferRate,
                        string WiFiPorts, string MU_MIMO, string Price, double Rating);

