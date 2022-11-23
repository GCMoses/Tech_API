namespace ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;


public record RouterUpdateDTO(string Name, string RAM, string TransferRate,
                              string WiFiPorts, string MU_MIMO, string Price, double Rating);

