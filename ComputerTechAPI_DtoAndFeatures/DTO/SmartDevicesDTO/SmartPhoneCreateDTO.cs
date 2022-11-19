namespace ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;


public record SmartPhoneCreateDTO(string Name, string ImgURL, string BatteryLife, string Processor,
                                  string PlatForm, string Storage, string Ram, string Camera, string SoftwareVersion,
                                  string Sensors, string ScreenSize, string ChargerType, string ShortDescription,
                                  string Price, double Rating);
