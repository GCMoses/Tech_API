namespace ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;


public record LaptopUpdateDTO(string Name, string DisplayResolution, string Model, string DisplaySize,
                              string Processor, string HardDisk, string Ram, string OS,  
                              string Graphics, string Weight, string LaptopDescription,
                              string Price, double Rating);

