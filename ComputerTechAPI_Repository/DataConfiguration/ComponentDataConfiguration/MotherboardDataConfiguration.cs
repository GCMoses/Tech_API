using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration;

public class MotherboardDataConfiguration : IEntityTypeConfiguration<Motherboard>
{
    public void Configure(EntityTypeBuilder<Motherboard> builder)
    {
        builder.HasData
        (
        new Motherboard
        {
            Id = new Guid("1a73ef26-6453-43f4-bdc0-07d0f21fc12a"),
            Name = "Asus TUF Gaming X570-Plus (WI-FI) AMD Socket AM4 ATX Wi-Fi 5 Motherboard",
            MoboCPU = " Socket AM4, Compatible processor series",
            Chipset = "Ready for 2nd and 3rd Gen AMD Ryzen™ processors",
            MoboMaxMemory = "Supports up to 128GB Dual Channel DDR4-SDRAM",
            PCIExpress = "1x PCIe 4.0/3.0 x16, 1x PCIe 3.0/2.0 x16, 2x PCIe 4.0 x1 Slots",
            MoboUSBPorts = "1 USB 3.1 G2 Type-A, 1 USB 3.1 G2 Type-C, 4 USB 3.1 G1 Type-A, and 2 USB 2.0 ports",
            MoboConnectors = "8x SATA 6Gb/s Ports, 2x M.2 Slots",
            Price = "R3200,00 up to R4300,00",
            Rating = 9.4,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new Motherboard
        {
            Id = new Guid("109c947e-a4f1-4f00-84d9-0a885b89e51c"),
            Name = "GIGABYTE Intel Z690 Aorus Elite Motherboard (LGA 1700)",
            MoboCPU = "LGA1700",
            Chipset = "Intel Z690 Express Chipset",
            MoboMaxMemory = "4  DIMM SLOTS, Supports Up to 128GB DDR4",
            PCIExpress = "1x PCI-E 5.0 x16, 2x PCI-E 3.0 x16 Slots",
            MoboUSBPorts = "1 x USB 3.2 Gen2 Type-C, 1 x USB 3.2 Gen2 Type-A, 4 x USB 3.2 Gen1 Type-A, 4 x USB 2.0 Type-A",
            MoboConnectors = "6x SATA 6Gbps, 3x M.2 Gen4 x4",
            Price = "R1800,00 up to R2500,00",
            Rating = 9.2,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
