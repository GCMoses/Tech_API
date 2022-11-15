using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTech_Repository.DataConfiguration;

public class CaseDataConfiguration : IEntityTypeConfiguration<Case>
{
    public void Configure(EntityTypeBuilder<Case> builder)
    {
        builder.HasData
        (
        new Case
        {
            Id = new Guid("e4148db2-3007-4f27-9cff-46b1caba4545"),
            Name = "Thermaltake Core P5 Tempered Glass",
            FormFactor = "ATX | Micro - ATX | Mini - ITX",
            DriveBays = 5,
            ExpansionSlots = 7,
            FanSupport = "3x 140 mm | 4x 120 mm(120 | 140)",
            GPULenghtLimit = "320mm",
            NetWeight = "18.4kg",
            Price = "R1200,00 up to R1600,00",
            Rating = 9.2,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new Case
        {
            Id = new Guid("a3b90db4-f3e4-4470-bdce-205907919e2c"),
            Name = "Cooler Master MasterBox TD500 Crystal",
            FormFactor = "ATX | Micro - ATX | Mini - ITX",
            DriveBays = 6,
            ExpansionSlots = 6,
            FanSupport = "Top 120mm x 3 / 140mm x 2, Front 120mm x 3/140mm x 2, Rear 120mm x 1",
            GPULenghtLimit = "410mm",
            NetWeight = "6.95kg",
            Price = "R3200,00 up to R4400,00",
            Rating = 9.3,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
