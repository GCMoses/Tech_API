using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration;

public class CPUCoolerDataConfiguration : IEntityTypeConfiguration<CPUCooler>
{
    public void Configure(EntityTypeBuilder<CPUCooler> builder)
    {
        builder.HasData
        (
        new CPUCooler
        {
            Id = new Guid("b6589538-2fc1-4912-bf0f-fdbf7279d302"),
            Name = "Corsair iCUE H150i Elite CAPELLIX 360mm Liquid CPU Cooler – White",
            BuiltInFan = "MN-AT-PC0175",
            Radiator = "397mm x 120mm x 27mm",
            MaxFanNoiseLevel = "10 – 37 dBA",
            PWMSupport = "Three 120mm Corsair ML series magnetic Levitation PWM fans",
            MaxAirflow = "75 CFM",
            NumberOfFans = 3,
            SocketSupport = "Intel LGA1200, 1150, 1151, 1155, 1156, 1366, 2011, 2066, AMD AM4, AM3, AM2, sTRX4, sTR4",
            Price = "R3200,00 up to R3500,00",
            Rating = 9.4,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new CPUCooler
        {
            Id = new Guid("71e42e0b-ddce-4b59-95d6-a7ab9328d072"),
            Name = "Cooler Master MasterLiquid ML360 Sub-Zero CPU Cooler",
            BuiltInFan = "MN-TT-PC0175",
            Radiator = "394 x 119.6 x 27.2 mm",
            MaxFanNoiseLevel = "8 - 26 dBA",
            PWMSupport = "Triple 120mm PWM Fans",
            MaxAirflow = "59 CFM",
            NumberOfFans = 3,
            SocketSupport = "LGA1200, 1700",
            Price = "R3200,00 up to R4500,00",
            Rating = 9.1,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
