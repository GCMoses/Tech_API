using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ComputerTechAPI_Entities.Tech_Models;

namespace ComputerTech_Repository.DataConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData
        (
        new Product
        {
            Id = new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"),
            Category = "PC & Gaming Accessories",
        },
        new Product
        {
            Id = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"),
            Category = "PC Components",
        },
        new Product
        {
            Id = new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"),
            Category = "Gaming Devices",
        },
        new Product
        {
            Id = new Guid("86a3510e-bf98-434e-9685-809b0e5dd36f"),
            Category = "Networking Devices",
        },
        new Product
        {
            Id = new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"),
            Category = "Latop and PC's",
        },
        new Product
        {
            Id = new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"),
            Category = "Smart Devices",
        }
        );

    }
}

