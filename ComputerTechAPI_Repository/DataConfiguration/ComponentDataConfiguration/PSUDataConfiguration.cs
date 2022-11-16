using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration;

public class PSUDataConfiguration : IEntityTypeConfiguration<PSU>
{
    public void Configure(EntityTypeBuilder<PSU> builder)
    {
        builder.HasData
        (
        new PSU
        {
            Id = new Guid("c9a524a6-a7d6-47e1-b194-7cc43f61928b"),
            Name = "Asus TUF Gaming 750W ATX PSU",
            RatedOutputPower = "750W",
            PlusCertified = "80Plus Bronze",
            Connectors = "24/20-pin x1, CPU 4 + 4 - pin x2, PCI-E 6+2-pin x4, SATA x8, Periplheral x4",
            Price = "R1200,00 up to R1700,00",
            Rating = 8.7,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new PSU
        {
            Id = new Guid("939f70fe-e1b2-4eef-aa39-e3e592815526"),
            Name = "Gigabyte P750GM power supply unit 750 W 20+4 pin ATX Black 80 PLUS Gold, 750W, Active PFC, 120mm",
            RatedOutputPower = "750W",
            PlusCertified = "80Plus Bronze",
            Connectors = "24/20-pin x1, CPU 4 + 4 - pin x2, PCI-E 6+2-pin x4, SATA x8, Periplheral x4",
            Price = "R1200,00 up to R1700,00",
            Rating = 9.6,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
