using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComputerTech_Repository.DataConfiguration.GamingDataConfiguration;

public class GamingKeyboardDataConfiguration : IEntityTypeConfiguration<GamingKeyboard>
{
    public void Configure(EntityTypeBuilder<GamingKeyboard> builder)
    {
        builder.HasData
        (
        new GamingKeyboard
        {
            Id = new Guid("5b1d1692-3e47-4078-be2e-6008f6163f50"),
            Name = "Corsair K100 RGB Optical-Mechanical Gaming Keyboard – Corsair OPX Switch Keyboard",
            Matrix = "110 Keys",
            Connector = "2 x USB 3.0 or 3.1 Type-A",
            KeyboardLayout = "NA",
            Lighting = "RGB",
            KeySwitches = "CORSAIR OPX Optical-Mechanical",
            AdjustableHeight = "Yes",
            Price = "R3200,00 up to R35000,00",
            Rating = 9.4,
            ProductId = new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"),

        },
        new GamingKeyboard
        {
            Id = new Guid("edae3ba8-5568-471c-ba13-8561bfdf657c"),
            Name = "ARYAMAN RGB MECHANICAL Gaming Keyboard – Black",
            Matrix = "104 Keys with anti-ghosting",
            Connector = " Gold-plated USB-A",
            KeyboardLayout = "QWERTY",
            Lighting = "RGB",
            KeySwitches = "OUTEMU Blue",
            AdjustableHeight = "Yes",
            Price = "R3200,00 up to R35000,00",
            Rating = 8.6,
            ProductId = new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476")
        }
      );
    }
}