using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerTechAPI_Repository.DataConfiguration.PCDataConfiguration;

public class LaptopDataConfiguration : IEntityTypeConfiguration<Laptop>
{
    public void Configure(EntityTypeBuilder<Laptop> builder)
    {
        builder.HasData
        (
        new Laptop
        {
            Id = new Guid("e0b375b3-5e85-4975-858b-bbd6457c4a5d"),
            Name = "Dell Inspiron G15 5511",
            Model = "G15 5511",
            DisplaySize = "15.6-inch",
            DisplayResolution = "FHD, 1920 x 1080, 165 Hz",
            Processor = "11th Generation Intel® Core™ i7-11800H (24 MB Cache, 8 Core, 2.30 GHz to 4.60 GHz)",
            HardDisk = "1 TB, M.2 2280, PCIe NVMe Gen3 x4, SSD",
            Ram = "16 GB, 2 x 8 GB, Dual-Channel DDR4, 3200 MHz",
            OS = "Windows 11 Home, 64-bit",
            Graphics = "Integrated: Intel®UHD Graphics",
            Weight = "2.65kg.",
            Price = "R15400,00 up to R19000,00",
            LaptopDescription = "Modern, sleek and easy to carry. What more could you want? You’ll game in style with this special edition 15-inch laptop featuring a contemporary aluminum cover and iridescent logo. For an even bolder look, choose the optional 4-zone RGB backlit keyboard with WASD which you can control through the Alienware Command Center.",
            Rating = 9.8,
            ProductId = new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"),

        },
        new Laptop
        {
            Id = new Guid("ecc8c004-bcd3-4e50-ad40-3191be9e73e2"),
            Name = "MSI Sword 15 15.6-inch FHD Laptop SWORD 15",
            Model = "A12UD-474ZA",
            DisplaySize = "15.6-inch",
            DisplayResolution = "144Hz IPS Full HD (1920x1080)",
            Processor = "Intel Core i7-12700H",
            HardDisk = "512GB SSD",
            Ram = "16GB RAM",
            OS = "Windows 11 Pro",
            Graphics = "RTX 3050 Ti 8GB",
            Weight = "2.25kg.",
            Price = "R14300,00 up to R18000,00",
            LaptopDescription = "MSI Sword 15 15.6-inch FHD Laptop - Intel Core i7-12700H 512GB SSD 16GB RAM RTX 3050 Ti Windows 11 Pro SWORD 15 A12UD-474ZA Sword 15 is tailored for those who love RPG games. It's powerful yet sturdy and the blue backlit keyboard is exclusively modulated to provide a distinctive color that will create the best gaming atmosphere for avid gamers.",
            Rating = 9.6,
            ProductId = new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b")
        }
      );
    }
}