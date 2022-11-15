using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerTech_Repository.DataConfiguration.GamingDataConfiguration;

public class GamingHeadphonesAndHeadsetDataConfiguration : IEntityTypeConfiguration<GamingHeadphonesAndHeadset>
{
    public void Configure(EntityTypeBuilder<GamingHeadphonesAndHeadset> builder)
    {
        builder.HasData
        (
        new GamingHeadphonesAndHeadset
        {
            Id = new Guid("7e9c815e-d538-4118-adfb-c419734e5ec6"),
            Name = "EPOS I Sennheiser GAME ONE Gaming Headset, Open Acoustic, Noise-canceling mic, Flip-To-Mute",
            Interface = "Wired",
            Connector = "3.5MM Audio Jack",
            Compatability = "PC / Soft phone, PS4, Xbox One, Nintendo Switch, Mac OSX, PS5, Xbox Series X",
            Foldability = "Foldable Architecture Crafted with a durable shock-resistant plastic architecture",
            Price = "R3200,00 up to R35000,00",
            Rating = 8.4,
            ProductId = new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"),

        },
        new GamingHeadphonesAndHeadset
        {
            Id = new Guid("d1001f69-46f1-4ba5-b1a7-92e5441d8d4d"),
            Name = "MSI IMMERSE GH61 7.1 Virtual Surround Sound Gaming Headset",
            Interface = "Wired",
            Connector = "USB & 3.5 MM CONNECTOR With both USB and 3.5 mm connector options supplied",
            Compatability = "PC, laptop, and mobile devices",
            Foldability = "GH61’s foldable design",
            Price = "R1820,00 up to R2000,00",
            Rating = 9.0,
            ProductId = new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476")
        }
      );
    }
}