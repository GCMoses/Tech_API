using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerTech_Repository.DataConfiguration.PCDataConfiguration;

public class DroneDataConfiguration : IEntityTypeConfiguration<Drone>
{
    public void Configure(EntityTypeBuilder<Drone> builder)
    {
        builder.HasData
        (
        new Drone
        {
            Id = new Guid("f49ffbde-38cf-4f2d-b785-7f391cec79aa"),
            Name = "DJi Avata",
            FlightTime = "15.6-inch",
            MaxSpeed = "140 km/hr",
            RemoteController = "DJI Goggles 2, DJI FPV Goggles V2, DJI FPV Remote Controller 2, and DJI Motion Controller",
            Camera = "4K/60fps",
            BatteryLife = "Li-ion 2420 mAh",
            Price = "R22300-R28200",
            Rating = 8.9,
            ProductId = new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"),

        },
        new Drone
        {
            Id = new Guid("0afa2038-bb78-4eef-b4c7-b8f29d8801bc"),
            Name = "Skydio 2+",
            FlightTime = "27 Minutes",
            MaxSpeed = "57 km/hr",
            RemoteController = "Rechargeable Controller with USB Type C input",
            Camera = "12 megapixel stills, 4K HDR video",
            Price = "R32200,00 up to R35000,00",
            BatteryLife = "Lithium ion 5410 mAh",
            Rating = 9.1,
            ProductId = new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb")
        }
      );
    }
}