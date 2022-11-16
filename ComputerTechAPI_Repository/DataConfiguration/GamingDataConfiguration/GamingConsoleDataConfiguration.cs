using ComputerTechAPI_Entities.Tech_Models.Gaming;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration;

public class GamingConsoleDataConfiguration : IEntityTypeConfiguration<GamingConsole>
{
    public void Configure(EntityTypeBuilder<GamingConsole> builder)
    {
        builder.HasData
        (
        new GamingConsole
        {
            Id = new Guid("1364f79a-bb8b-4c91-addc-406f8665cd3c"),
            Name = "PS5",
            ImgURL = "https://www.flickr.com/photos/196942735@N04/52500020391/in/dateposted-public/",
            Model = "PlayStation 5",
            DiskDrive = "4K Blu-ray disc drive",
            ResolutionAndFrameRate = "12GB GDDR6X",
            HardDisk = "Custom 825GB SSD, expandable NVMe M.2 SSD slot",
            Processor = "AMD Zen 2",
            Graphics = "10.3 teraflop RDNA 2 GPU",
            RAM = "16GB GDDR6",
            Controller = "DualSense Wireless Controller",
            Price = "R12000,00 up to R15000,00",
            ShortDescription = "The PS5 is a powerful console offering a sublime current-gen gaming experience. Its library of exclusive games makes fantastic use of the DualSense controller, 3D Audio, and the console's lightning-fast SSD. It might be too big for some setups, though, and a handful of issues hold it back from perfection.\r\n\r\nUS$499,99\r\nat Amazon\r\nUS$499,99\r\nat GameStop",
            Rating = 9.2,
            ProductId = new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975")
        },
        new GamingConsole
        {
            Id = new Guid("79ac0bfd-791c-40f5-bb48-371af8833913"),
            Name = "PS VITA",
            ImgURL = "https://www.flickr.com/photos/196942735@N04/52500670344/in/dateposted-public/",
            Model = "PS VITA",
            DiskDrive = "CDRAM",
            ResolutionAndFrameRate = "960x544 resolution, 120fps at 320x240 (QVGA), 60fps at 640x480(VGA)",
            HardDisk = "1 GB flash memory (PCH-2000 model only)",
            Processor = "Quad-core ARM Cortex-A9 MPCore",
            Graphics = "128 MB VRAM",
            RAM = "512 MB RAM",
            Controller = "PlayStation Vita can indeed be used as a PS3 & PS4 Controller via remote play",
            Price = "R1000,00 up to R1200,00",
            ShortDescription = "The Playstation Vita GPU was a performance-segment gaming console graphics solution by Sony, launched on December 11th, 2011. Built on the 32 nm process, and based on the SGX543 MP4+ graphics processor, in its CXD5315GG variant, the device supports DirectX 10.1. The SGX543 MP4+ graphics processor is a relatively small chip with a die area of only 6 mm². It features 4 pixel shaders and 2 vertex shaders, 8 texture mapping units, and 4 ROPs. Sony includes 128 MB CDRAM memory, which are connected using a 64-bit memory interface. The GPU is operating at a frequency of 200 MHz, memory is running at 400 MHz.",
            Rating = 8.8,
            ProductId = new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975")
        }
      );
    }
}
