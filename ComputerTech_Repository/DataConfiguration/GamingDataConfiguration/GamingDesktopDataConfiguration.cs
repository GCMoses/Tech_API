using ComputerTechAPI_Entities.Tech_Models.Gaming;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Net.WebRequestMethods;

namespace ComputerTech_Repository.DataConfiguration.GamingDataConfiguration;

public class GamingDesktopDataConfiguration : IEntityTypeConfiguration<GamingDesktop>
{
    public void Configure(EntityTypeBuilder<GamingDesktop> builder)
    {
        builder.HasData
        (
        new GamingDesktop
        {
            Id = new Guid("289d1c08-bb4a-4c1d-9407-ae43e5cd7797"),
            Name = "Digital Motorsports Ultimate Gaming PC - AMD Ryzen 7 3700X, 16GB DDR4 RAM, Radeon RX 6800XT 16GB, CPU Water Cooler",
            ImgURL = "https://www.flickr.com/photos/196942735@N04/52500414416/in/dateposted-public/",
            GamingCase = "Be-Quiet Pure base 500DX tower",
            CoolingSystem = "Be Quiet! WAK Pure LOOP 280mm Water Cooler",
            Processor = "AMD Ryzen 7 3700X 3.6GHz",
            HardDisk = "Kingston KC2500 - 250 GB SSD, 2TB Seagate Barracude HDD",
            Ram = "16GB 2xG.Skill AEGIS - 8GB - DDR4 - PC3200",
            OS = "Windows 10 Pro",
            Graphics = "Sapphire PULSE Radeon RX 6800 XT 16 GB",
            PSU = "Be-Quiet Straight Power 11 750W Gold",
            Price = "R42000,00 up to R47000,00",
            GamingPCDescription = "Our Ultimate Gaming PC features AMD Ryzen 7 3700X, a full Water-cooled System with 16GB DDR4-RAM and the all important Radeon RX 6800XT for unlimited graphics in the Be Quiet Pure base 500DX tower with extra sound isolation.",
            Rating = 9.8,
            ProductId = new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"),

        },
        new GamingDesktop
        {
            Id = new Guid("cf326876-671c-4727-93d7-f0cb27c7a11a"),
            Name = "Alienware Aurora R13 Desktop – i7, 32GB RAM, 1TB SSD, Win 11 Pro",
            ImgURL = "https://www.flickr.com/photos/196942735@N04/52500430151/in/dateposted-public/",
            GamingCase = "Alienware's Legend 2.0 chassis",
            CoolingSystem = "Dark, Liquid-Cooled",
            Processor = "12th Gen Intel(R) Core(TM) i7 12700KF (12-Core, 25MB Cache, 3.6GHz to 5GHz w/Turbo Boost Max 3.0)",
            HardDisk = "1TB M.2 PCIe NVMe Solid State Drive",
            Ram = "32GB Dual Channel DDR5 at 4400MHz; up to 128GB (additional memory sold separately).",
            OS = "Windows 11 Pro",
            Graphics = "NVIDIA® GeForce RTX™ 3070 8GB GDDR6",
            PSU = "750W Platinum PSU",
            Price = "R52000,00 up to R55000,00",
            GamingPCDescription = "The redesigned Alienware Aurora R13 brings the heat with Intel’s impressive 12th Generation “Alder Lake” CPUs and up to Nvidia GeForce RTX 3090 graphics, all in a new-look chassis with a side window.",
            Rating = 9.8,
            ProductId = new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975")
        }
      );
    }
}