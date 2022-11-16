using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration.ComponentDataConfiguration;

public class SSDDataConfiguration : IEntityTypeConfiguration<SSD>
{
    public void Configure(EntityTypeBuilder<SSD> builder)
    {
        builder.HasData
        (
        new SSD
        {
            Id = new Guid("83dd3c9e-523f-4917-8570-a1678a46445b"),
            Name = "WD Blue 3D 2.5-inch 1TB Serial ATA III Internal SSD WD S100T2B0A",
            StorageCapacity = " 1024GB",
            Interface = "6 Gb/s",
            ReadWriteSpeed = "Read speed 560 MB/s, Write speed 530 MB/s",
            CacheMemory = "64MB",
            FormFactor = "2.5 Inch",
            Price = "R1500,00 up to R1800,00",
            Rating = 9.0,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new SSD
        {
            Id = new Guid("0db44a46-e172-421a-86e6-ddd86832a5f4"),
            Name = "980 PRO PCle 4.0 NVMe M.2 SSD 1 TB",
            StorageCapacity = " 1024GB",
            Interface = "PCIe Gen 4.0 x4, NVMe 1.3c",
            ReadWriteSpeed = "Read speed 560 MB/s, Write speed 530 MB/s",
            CacheMemory = "64MB",
            FormFactor = "M.2 2280",
            Price = "R1200,00 up to R1600,00",
            Rating = 8.3,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
