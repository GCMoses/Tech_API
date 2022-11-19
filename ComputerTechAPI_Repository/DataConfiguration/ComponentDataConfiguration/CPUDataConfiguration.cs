using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration;

public class CPUDataConfiguration : IEntityTypeConfiguration<CPU>
{
    public void Configure(EntityTypeBuilder<CPU> builder)
    {
        builder.HasData
        (
        new CPU
        {
            Id = new Guid("76935143-b5db-4acb-9a48-ccc5c437b5c7"),
            Name = "AMD Ryzen 5 5600",
            BaseClock = "3.7GHz",
            BoostClock = "4.6GHz",
            HyperThreading = "Yes", //Yes sound much better than true therefore I don't use bool
            CPUCore = "6/12",
            CpuTDP = "65W",
            Cache = "32MB of L3 cache",
            Socket = "AMD Socket AM4",
            Price = "R3200,00 up to R3500,00",
            Rating = 7.0,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        },
        new CPU
        {
            Id = new Guid("b02a9311-744f-4e70-8c99-3839e1ab5379"),
            Name = "Intel® Core™ i9-11900H Processor",
            BaseClock = "2.5GHz",
            BoostClock = "5.2GHz",
            HyperThreading = "Yes",
            CPUCore = "8/16",
            CpuTDP = "65W",
            Cache = "16 MB Intel® Smart Cache",
            Socket = "BGA-1787",
            Price = "R1700,00 up to R2200,00",
            Rating = 9.4,
            ProductId = new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d")
        }
      );
    }
}
