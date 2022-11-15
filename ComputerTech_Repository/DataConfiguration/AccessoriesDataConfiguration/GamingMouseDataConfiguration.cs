using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerTech_Repository.DataConfiguration.GamingDataConfiguration;

public class GamingMouseDataConfiguration : IEntityTypeConfiguration<GamingMouse>
{
    public void Configure(EntityTypeBuilder<GamingMouse> builder)
    {
        builder.HasData
        (
        new GamingMouse
        {
            Id = new Guid("5caac7fa-86de-41c2-b661-50570d500d2e"),
            Name = "ASUS ROG SPATHA GAMING MOUSE",
            PollRate = "2000 Hz (wireless), 1000Hz (wired)",
            Connector = "Wireless and Wired. IT'S YOUR CHOICE",
            Buttons = "12 programmable buttons",
            Weight = " 175g",
            Lighting = "ROG Spatha X. Lighting",
            Price = "R3200,00 up to R35000,00",
            Rating = 8.8,
            ProductId = new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"),

        },
        new GamingMouse
        {
            Id = new Guid("ed2389ff-3288-43c8-a8d7-d0c91075135e"),
            Name = "SNIPER PRO 16000DPI Wireless RGB Gaming Mouse – Black",
            PollRate = "125 – 1 000Hz",
            Connector = "Wireless and Wired. IT'S YOUR CHOICE",
            Buttons = "9 User Programmable Buttons, 2 Side Buttons, Rapid Fire Button",
            Weight = " 159g",
            Lighting = "RGB",
            Price = "R3200,00 up to R35000,00",
            Rating = 8.4,
            ProductId = new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476")
        }
      );
    }
}