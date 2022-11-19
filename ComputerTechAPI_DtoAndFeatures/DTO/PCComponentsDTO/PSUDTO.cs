namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record PSUDTO(Guid Id, string Name, string RatedOutputPower, string PlusCertified,
                        string Connectors, string Price, double Rating);

