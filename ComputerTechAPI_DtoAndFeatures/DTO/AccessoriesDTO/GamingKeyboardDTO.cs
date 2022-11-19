namespace ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;


public record GamingKeyboardDTO(Guid Id, string Name, string Matrix, string Connector,
                                         string KeyboardLayout, string Lighting, string KeySwitches, string AdjustableHeight,
                                         string Price, double Rating);

