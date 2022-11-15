using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTech_Repository.DataConfiguration;

public class RAMDataConfiguration : IEntityTypeConfiguration<RAM>
{
    public void Configure(EntityTypeBuilder<RAM> builder)
    {
        builder.HasData
        (
        new RAM
        {
            Id = new Guid("47a6d393-9834-469f-b77c-d98047874eaf"),
            Name = "Kingston 32GB 3200MHz DDR4 FURYBeastRGB",
            RamCapacity = "32GB",
            RAMSpeed = "3200 MHz",
            RAMType = "DDR4",
            Price = "R2200,00 up to R2500,00",
            Rating = 9.1,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new RAM
        {
            Id = new Guid("bd52bbb4-5ca9-4c20-9c59-f47e6b948c76"),
            Name = "Corsair Vegeance RS RGB 64GB (2x32GB) DDR4 RAM – 3600MHz",
            RamCapacity = "64GB",
            RAMSpeed = "3600 MHz",
            RAMType = "DDR4",
            Price = "R3800,00 up to R4400,00",
            Rating = 9.7,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
