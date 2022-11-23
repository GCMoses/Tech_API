namespace ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;


public record DroneUpdateDTO(string Name, string FlightTime, string MaxSpeed, string BatteryLife,
                             string RemoteController, string Camera, string Price, double Rating);

