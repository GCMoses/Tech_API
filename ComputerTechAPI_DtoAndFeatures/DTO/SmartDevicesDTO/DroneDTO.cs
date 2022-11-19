namespace ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;


public record DroneDTO(Guid Id, string Name, string FlightTime, string MaxSpeed, string BatteryLife,
                                string RemoteController, string Camera, string Price, double Rating);

