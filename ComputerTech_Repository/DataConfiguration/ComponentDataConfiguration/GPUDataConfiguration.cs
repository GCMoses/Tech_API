using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTech_Repository.DataConfiguration.ComponentDataConfiguration;

public class GPUDataConfiguration : IEntityTypeConfiguration<GPU>
{
    public void Configure(EntityTypeBuilder<GPU> builder)
    {
        builder.HasData
        (
        new GPU
        {
            Id = new Guid("7262ed78-1189-47fe-8f9d-cd7893ef4912"),
            Name = "MSI Nvidia GeForce RTX 3080 GAMING Z TRIO 12GB GDDR6X Graphics Card",
            Bus = "384-bit",
            GPUClock = "1815 MHz",
            VRAM = "12GB GDDR6X",
            Interface = "PCI Express® Gen 4",
            CoolingType = "TRI FROZR 2 Thermal Design",
            DXVersion = "12",
            Price = "R18 200,00 up to R23 000,00",
            Rating = 9.7,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new GPU
        {
            Id = new Guid("0f44b6df-908d-4df2-a2ea-d178e7ca5104"),
            Name = "Zotac GeForce RTX 3080 Gaming Trinity OC 10GB",
            Bus = "320-bit",
            GPUClock = "1725 MHz",
            VRAM = "10GB of GDDR6X VRAM",
            Interface = "PCIe 4.0",
            CoolingType = "IceStorm2.0 Advanced Cooler",
            DXVersion = "12",
            Price = "R17000,00 up to R19100,00",
            Rating = 9.4,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
