using ComputerTechAPI_Entities.Tech_Models.Networking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration;

public class RouterDataConfiguration : IEntityTypeConfiguration<Router>
{
    public void Configure(EntityTypeBuilder<Router> builder)
    {
        builder.HasData
        (
        new Router
        {
            Id = new Guid("558ac570-0e06-49b4-858e-d5b18a2f5b8b"),
            Name = "Xiaomi Mi AIoT Wireless Router AC235012th Generation Intel Core i5 HexaCore Performance Workstation",
            RAM = "128MB RAM",
            TransferRate = "Wireless speeds of up to 2183Mbps",
            WiFiPorts = "4 & a WAN port",
            MU_MIMO = "Supported",     //I'm not a fan of bool... I'll rather print out a sting with the value  
            Price = "R3200,00 up to R3800,00",
            Rating = 8.8,
            ProductId = new Guid("86a3510e-bf98-434e-9685-809b0e5dd36f"),

        },
        new Router
        {
            Id = new Guid("8645c943-f730-4536-9041-a7c190d11142"),
            Name = "Ubiquiti UniFi Dream Machine",
            RAM = "128MB RAM",
            TransferRate = "12th Gen Intel® H610 Chipset",
            WiFiPorts = "8 & a WAN port",
            MU_MIMO = "16GB DDR4 RAM @ 3200MHz – open slots for upgrades",
            Price = "R11200,00 up to R14000,00",
            Rating = 8.8,
            ProductId = new Guid("86a3510e-bf98-434e-9685-809b0e5dd36f")
        }
      );
    }
}
