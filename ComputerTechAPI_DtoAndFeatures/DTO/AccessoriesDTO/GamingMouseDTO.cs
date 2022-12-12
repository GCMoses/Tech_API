namespace ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;


public record GamingMouseDTO(Guid Id, string Name, string PollRate, string Connector,
                                      string Buttons, string Weight, string Lighting,
                                      string Price, double Rating);

