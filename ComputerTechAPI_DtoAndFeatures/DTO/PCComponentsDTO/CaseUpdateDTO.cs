namespace ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;


public record CaseUpdateDTO(string Name, string FormFactor, string DriveBays,
                            string ExpansionSlots, string FanSupport, string GPULenghtLimit,
                            string NetWeight, string Price, double Rating);

