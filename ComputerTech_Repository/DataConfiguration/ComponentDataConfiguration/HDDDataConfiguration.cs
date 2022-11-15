using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTech_Repository.DataConfiguration;

public class HDDDataConfiguration : IEntityTypeConfiguration<HDD>
{
    public void Configure(EntityTypeBuilder<HDD> builder)
    {
        builder.HasData
        (
        new HDD
        {
            Id = new Guid("dd32228a-8391-4e0d-ae06-cdb80208c018"),
            Name = "Seagate Barracuda ST5000LM000",
            StorageCapacity = " 5000 GB",
            Interface = "SATA III 6 Gb/s",
            CacheSize = "128MB",
            FormFactor = "2.5 Inch",
            Price = "R2000,00 up to R2400,00",
            Rating = 9.0,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new HDD
        {
            Id = new Guid("7bcf864b-9dac-4c9a-bc93-8c060e5693fc"),
            Name = "WD Purple 1TB SATA HDD",
            StorageCapacity = " 1000 GB",
            Interface = "SATA III 6 Gb/s",
            CacheSize = "64MB",
            FormFactor = "3.5 Inch",
            Price = "R750,00 up to R900,00",
            Rating = 8.7,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
