namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record PSUCreateDTO(string Name, string RatedOutputPower, string PlusCertified,
                           string Connectors, string Price, double Rating);

