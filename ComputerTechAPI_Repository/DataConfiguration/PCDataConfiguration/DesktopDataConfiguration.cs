using ComputerTechAPI_Entities.Tech_Models.PC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration;

public class DesktopDataConfiguration : IEntityTypeConfiguration<Desktop>
{
    public void Configure(EntityTypeBuilder<Desktop> builder)
    {
        builder.HasData
        (
        new Desktop
        {
            Id = new Guid("fa74efcb-8d53-4aae-9e50-0922a48aa250"),
            Name = "12th Generation Intel Core i5 HexaCore Performance Workstation",
            Model = "MN-TT-PC0175",
            Processor = "12th Gen Intel® H610 Chipset",
            HardDisk = "500GB M.2 PCIe 3.0 NVMe SSD Primary Drive – 2500MB/s, 2TB (2000GB) HDD internal secondary storage drive",
            Ram = "16GB DDR4 RAM @ 3200MHz – open slots for upgrades",
            OS = "Windows 11 Pro",
            Graphics = "Intel® UHD Graphics 730 integrated - Supports 7680 x 4320 @ 60Hz",
            Price = "R13000,00 up to R14000,00",
            DesktopPCDescription = "This Micro Tower Desktop PC is the perfect home or office companion. Thanks to high-end components like the 12th Generation Intel Core i5 CPU and 16GB of fast DDR4 RAM, this PC is an efficient elegant machine designed for a smooth experience and multitasking purposes! Featuring 500GB of ultra-fast SSD, gone are the days of waiting for an application to load! With 2TB of internal mass storage, you never have to worry about running out of space! This PC is perfect for home or office use, but easily supports high demand applications!",
            Rating = 8.8,
            ProductId = new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"),

        },
        new Desktop
        {
            Id = new Guid("ff4d2693-e52e-4a72-bec3-8a5ba6143f82"),
            Name = "ASUS ExpertCentre D5",
            Model = "D500SE",
            Processor = "Intel Core i5 11400",
            HardDisk = "1TB HDD Storage",
            Ram = "8GB RAM DDR4.",
            OS = "Windows 11 Home",
            Graphics = "Intel UHD Graphics 730",
            Price = "R9000,00 up to R11000,00",
            DesktopPCDescription = "This Micro Tower Desktop PC is the perfect home or office companion. Thanks to high-end components like the 12th Generation Intel Core i5 CPU and 16GB of fast DDR4 RAM, this PC is an efficient elegant machine designed for a smooth experience and multitasking purposes! Featuring 500GB of ultra-fast SSD, gone are the days of waiting for an application to load! With 2TB of internal mass storage, you never have to worry about running out of space! This PC is perfect for home or office use, but easily supports high demand applications!",
            Rating = 9.8,
            ProductId = new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b")
        }
      );
    }
}
