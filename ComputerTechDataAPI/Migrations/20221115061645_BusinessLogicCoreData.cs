using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerTechDataAPI.Migrations
{
    public partial class BusinessLogicCoreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Category" },
                values: new object[,]
                {
                    { new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), "PC Components" },
                    { new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"), "Gaming Devices" },
                    { new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"), "Smart Devices" },
                    { new Guid("86a3510e-bf98-434e-9685-809b0e5dd36f"), "Networking Devices" },
                    { new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"), "PC & Gaming Accessories" },
                    { new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"), "Latop and PC's" }
                });

            migrationBuilder.InsertData(
                table: "CPUCoolers",
                columns: new[] { "CPUCoolerId", "BuiltInFan", "MaxAirflow", "MaxFanN~oiseLevel", "Name", "NumberOfFans", "PWMSupport", "Price", "ProductId", "Radiator", "Rating", "SocketSupport" },
                values: new object[,]
                {
                    { new Guid("71e42e0b-ddce-4b59-95d6-a7ab9328d072"), "MN-TT-PC0175", "59 CFM", "8 - 26 dBA", "Cooler Master MasterLiquid ML360 Sub-Zero CPU Cooler", 3, "Triple 120mm PWM Fans", "R3200,00 up to R4500,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), "394 x 119.6 x 27.2 mm", 9.0999999999999996, "LGA1200, 1700" },
                    { new Guid("b6589538-2fc1-4912-bf0f-fdbf7279d302"), "MN-AT-PC0175", "75 CFM", "10 – 37 dBA", "Corsair iCUE H150i Elite CAPELLIX 360mm Liquid CPU Cooler – White", 3, "Three 120mm Corsair ML series magnetic Levitation PWM fans", "R3200,00 up to R3500,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), "397mm x 120mm x 27mm", 9.4000000000000004, "Intel LGA1200, 1150, 1151, 1155, 1156, 1366, 2011, 2066, AMD AM4, AM3, AM2, sTRX4, sTR4" }
                });

            migrationBuilder.InsertData(
                table: "CPUs",
                columns: new[] { "CPUId", "BaseClock", "BoostClock", "CPUCore", "Cache", "CpuTDP", "HyperThreading", "Name", "Price", "ProductId", "Rating", "Socket" },
                values: new object[,]
                {
                    { new Guid("76935143-b5db-4acb-9a48-ccc5c437b5c7"), "3.7GHz", "4.6GHz", "6/12", "32MB of L3 cache", "65W", "Yes", "AMD Ryzen 5 5600", "R3200,00 up to R3500,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 7.0, "AMD Socket AM4" },
                    { new Guid("b02a9311-744f-4e70-8c99-3839e1ab5379"), "2.5GHz", "5.2GHz", "8/16", "16 MB Intel® Smart Cache", "65W", "Yes", "Intel® Core™ i9-11900H Processor", "R1700,00 up to R2200,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.4000000000000004, "BGA-1787" }
                });

            migrationBuilder.InsertData(
                table: "Cases",
                columns: new[] { "CaseId", "DriveBays", "ExpansionSlots", "FanSupport", "FormFactor", "GPULenghtLimit", "Name", "NetWeight", "Price", "ProductId", "Rating" },
                values: new object[,]
                {
                    { new Guid("a3b90db4-f3e4-4470-bdce-205907919e2c"), 6, 6, "Top 120mm x 3 / 140mm x 2, Front 120mm x 3/140mm x 2, Rear 120mm x 1", "ATX | Micro - ATX | Mini - ITX", "410mm", "Cooler Master MasterBox TD500 Crystal", "6.95kg", "R3200,00 up to R4400,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.3000000000000007 },
                    { new Guid("e4148db2-3007-4f27-9cff-46b1caba4545"), 5, 7, "3x 140 mm | 4x 120 mm(120 | 140)", "ATX | Micro - ATX | Mini - ITX", "320mm", "Thermaltake Core P5 Tempered Glass", "18.4kg", "R1200,00 up to R1600,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.1999999999999993 }
                });

            migrationBuilder.InsertData(
                table: "Desktops",
                columns: new[] { "DesktopId", "DesktopPCDescription", "Graphics", "HardDisk", "Model", "Name", "OS", "Price", "Processor", "ProductId", "Ram", "Rating" },
                values: new object[,]
                {
                    { new Guid("fa74efcb-8d53-4aae-9e50-0922a48aa250"), "This Micro Tower Desktop PC is the perfect home or office companion. Thanks to high-end components like the 12th Generation Intel Core i5 CPU and 16GB of fast DDR4 RAM, this PC is an efficient elegant machine designed for a smooth experience and multitasking purposes! Featuring 500GB of ultra-fast SSD, gone are the days of waiting for an application to load! With 2TB of internal mass storage, you never have to worry about running out of space! This PC is perfect for home or office use, but easily supports high demand applications!", "Intel® UHD Graphics 730 integrated - Supports 7680 x 4320 @ 60Hz", "500GB M.2 PCIe 3.0 NVMe SSD Primary Drive – 2500MB/s, 2TB (2000GB) HDD internal secondary storage drive", "MN-TT-PC0175", "12th Generation Intel Core i5 HexaCore Performance Workstation", "Windows 11 Pro", "R13000,00 up to R14000,00", "12th Gen Intel® H610 Chipset", new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"), "16GB DDR4 RAM @ 3200MHz – open slots for upgrades", 8.8000000000000007 },
                    { new Guid("ff4d2693-e52e-4a72-bec3-8a5ba6143f82"), "This Micro Tower Desktop PC is the perfect home or office companion. Thanks to high-end components like the 12th Generation Intel Core i5 CPU and 16GB of fast DDR4 RAM, this PC is an efficient elegant machine designed for a smooth experience and multitasking purposes! Featuring 500GB of ultra-fast SSD, gone are the days of waiting for an application to load! With 2TB of internal mass storage, you never have to worry about running out of space! This PC is perfect for home or office use, but easily supports high demand applications!", "Intel UHD Graphics 730", "1TB HDD Storage", "D500SE", "ASUS ExpertCentre D5", "Windows 11 Home", "R9000,00 up to R11000,00", "Intel Core i5 11400", new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"), "8GB RAM DDR4.", 9.8000000000000007 }
                });

            migrationBuilder.InsertData(
                table: "Drones",
                columns: new[] { "DroneId", "BatteryLife", "Camera", "FlightTime", "MaxSpeed", "Name", "Price", "ProductId", "Rating", "RemoteController" },
                values: new object[,]
                {
                    { new Guid("0afa2038-bb78-4eef-b4c7-b8f29d8801bc"), "Lithium ion 5410 mAh", "12 megapixel stills, 4K HDR video", "27 Minutes", "57 km/hr", "Skydio 2+", "R32200,00 up to R35000,00", new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"), 9.0999999999999996, "Rechargeable Controller with USB Type C input" },
                    { new Guid("f49ffbde-38cf-4f2d-b785-7f391cec79aa"), "Li-ion 2420 mAh", "4K/60fps", "15.6-inch", "140 km/hr", "DJi Avata", "R22300-R28200", new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"), 8.9000000000000004, "DJI Goggles 2, DJI FPV Goggles V2, DJI FPV Remote Controller 2, and DJI Motion Controller" }
                });

            migrationBuilder.InsertData(
                table: "GPUs",
                columns: new[] { "GPUId", "Bus", "CoolingType", "DXVersion", "GPUClock", "Interface", "Name", "Price", "ProductId", "Rating", "VRAM" },
                values: new object[,]
                {
                    { new Guid("0f44b6df-908d-4df2-a2ea-d178e7ca5104"), "320-bit", "IceStorm2.0 Advanced Cooler", "12", "1725 MHz", "PCIe 4.0", "Zotac GeForce RTX 3080 Gaming Trinity OC 10GB", "R17000,00 up to R19100,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.4000000000000004, "10GB of GDDR6X VRAM" },
                    { new Guid("7262ed78-1189-47fe-8f9d-cd7893ef4912"), "384-bit", "TRI FROZR 2 Thermal Design", "12", "1815 MHz", "PCI Express® Gen 4", "MSI Nvidia GeForce RTX 3080 GAMING Z TRIO 12GB GDDR6X Graphics Card", "R18 200,00 up to R23 000,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.6999999999999993, "12GB GDDR6X" }
                });

            migrationBuilder.InsertData(
                table: "GamingConsoles",
                columns: new[] { "GamingConsoleId", "Controller", "DiskDrive", "Graphics", "HardDisk", "ImgURL", "Model", "Name", "Price", "Processor", "ProductId", "RAM", "Rating", "ResolutionAndFrameRate", "ShortDescription" },
                values: new object[,]
                {
                    { new Guid("1364f79a-bb8b-4c91-addc-406f8665cd3c"), "DualSense Wireless Controller", "4K Blu-ray disc drive", "10.3 teraflop RDNA 2 GPU", "Custom 825GB SSD, expandable NVMe M.2 SSD slot", "https://www.flickr.com/photos/196942735@N04/52500020391/in/dateposted-public/", "PlayStation 5", "PS5", "R12000,00 up to R15000,00", "AMD Zen 2", new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"), "16GB GDDR6", 9.1999999999999993, "12GB GDDR6X", "The PS5 is a powerful console offering a sublime current-gen gaming experience. Its library of exclusive games makes fantastic use of the DualSense controller, 3D Audio, and the console's lightning-fast SSD. It might be too big for some setups, though, and a handful of issues hold it back from perfection.\r\n\r\nUS$499,99\r\nat Amazon\r\nUS$499,99\r\nat GameStop" },
                    { new Guid("79ac0bfd-791c-40f5-bb48-371af8833913"), "PlayStation Vita can indeed be used as a PS3 & PS4 Controller via remote play", "CDRAM", "128 MB VRAM", "1 GB flash memory (PCH-2000 model only)", "https://www.flickr.com/photos/196942735@N04/52500670344/in/dateposted-public/", "PS VITA", "PS VITA", "R1000,00 up to R1200,00", "Quad-core ARM Cortex-A9 MPCore", new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"), "512 MB RAM", 8.8000000000000007, "960x544 resolution, 120fps at 320x240 (QVGA), 60fps at 640x480(VGA)", "The Playstation Vita GPU was a performance-segment gaming console graphics solution by Sony, launched on December 11th, 2011. Built on the 32 nm process, and based on the SGX543 MP4+ graphics processor, in its CXD5315GG variant, the device supports DirectX 10.1. The SGX543 MP4+ graphics processor is a relatively small chip with a die area of only 6 mm². It features 4 pixel shaders and 2 vertex shaders, 8 texture mapping units, and 4 ROPs. Sony includes 128 MB CDRAM memory, which are connected using a 64-bit memory interface. The GPU is operating at a frequency of 200 MHz, memory is running at 400 MHz." }
                });

            migrationBuilder.InsertData(
                table: "GamingDesktops",
                columns: new[] { "GamingDesktopId", "CoolingSystem", "GamingCase", "GamingPCDescription", "Graphics", "HardDisk", "ImgURL", "Name", "OS", "PSU", "Price", "Processor", "ProductId", "Ram", "Rating" },
                values: new object[,]
                {
                    { new Guid("289d1c08-bb4a-4c1d-9407-ae43e5cd7797"), "Be Quiet! WAK Pure LOOP 280mm Water Cooler", "Be-Quiet Pure base 500DX tower", "Our Ultimate Gaming PC features AMD Ryzen 7 3700X, a full Water-cooled System with 16GB DDR4-RAM and the all important Radeon RX 6800XT for unlimited graphics in the Be Quiet Pure base 500DX tower with extra sound isolation.", "Sapphire PULSE Radeon RX 6800 XT 16 GB", "Kingston KC2500 - 250 GB SSD, 2TB Seagate Barracude HDD", "https://www.flickr.com/photos/196942735@N04/52500414416/in/dateposted-public/", "Digital Motorsports Ultimate Gaming PC - AMD Ryzen 7 3700X, 16GB DDR4 RAM, Radeon RX 6800XT 16GB, CPU Water Cooler", "Windows 10 Pro", "Be-Quiet Straight Power 11 750W Gold", "R42000,00 up to R47000,00", "AMD Ryzen 7 3700X 3.6GHz", new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"), "16GB 2xG.Skill AEGIS - 8GB - DDR4 - PC3200", 9.8000000000000007 },
                    { new Guid("cf326876-671c-4727-93d7-f0cb27c7a11a"), "Dark, Liquid-Cooled", "Alienware's Legend 2.0 chassis", "The redesigned Alienware Aurora R13 brings the heat with Intel’s impressive 12th Generation “Alder Lake” CPUs and up to Nvidia GeForce RTX 3090 graphics, all in a new-look chassis with a side window.", "NVIDIA® GeForce RTX™ 3070 8GB GDDR6", "1TB M.2 PCIe NVMe Solid State Drive", "https://www.flickr.com/photos/196942735@N04/52500430151/in/dateposted-public/", "Alienware Aurora R13 Desktop – i7, 32GB RAM, 1TB SSD, Win 11 Pro", "Windows 11 Pro", "750W Platinum PSU", "R52000,00 up to R55000,00", "12th Gen Intel(R) Core(TM) i7 12700KF (12-Core, 25MB Cache, 3.6GHz to 5GHz w/Turbo Boost Max 3.0)", new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"), "32GB Dual Channel DDR5 at 4400MHz; up to 128GB (additional memory sold separately).", 9.8000000000000007 }
                });

            migrationBuilder.InsertData(
                table: "GamingHeadphonesAndHeadsets",
                columns: new[] { "GamingHeadphonesAndHeadsetId", "Compatability", "Connector", "Foldability", "Interface", "Name", "Price", "ProductId", "Rating" },
                values: new object[,]
                {
                    { new Guid("7e9c815e-d538-4118-adfb-c419734e5ec6"), "PC / Soft phone, PS4, Xbox One, Nintendo Switch, Mac OSX, PS5, Xbox Series X", "3.5MM Audio Jack", "Foldable Architecture Crafted with a durable shock-resistant plastic architecture", "Wired", "EPOS I Sennheiser GAME ONE Gaming Headset, Open Acoustic, Noise-canceling mic, Flip-To-Mute", "R3200,00 up to R35000,00", new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"), 8.4000000000000004 },
                    { new Guid("d1001f69-46f1-4ba5-b1a7-92e5441d8d4d"), "PC, laptop, and mobile devices", "USB & 3.5 MM CONNECTOR With both USB and 3.5 mm connector options supplied", "GH61’s foldable design", "Wired", "MSI IMMERSE GH61 7.1 Virtual Surround Sound Gaming Headset", "R1820,00 up to R2000,00", new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"), 9.0 }
                });

            migrationBuilder.InsertData(
                table: "GamingKeyboards",
                columns: new[] { "GamingKeyboardId", "AdjustableHeight", "Connector", "KeySwitches", "KeyboardLayout", "Lighting", "Matrix", "Name", "Price", "ProductId", "Rating" },
                values: new object[,]
                {
                    { new Guid("5b1d1692-3e47-4078-be2e-6008f6163f50"), "Yes", "2 x USB 3.0 or 3.1 Type-A", "CORSAIR OPX Optical-Mechanical", "NA", "RGB", "110 Keys", "Corsair K100 RGB Optical-Mechanical Gaming Keyboard – Corsair OPX Switch Keyboard", "R3200,00 up to R35000,00", new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"), 9.4000000000000004 },
                    { new Guid("edae3ba8-5568-471c-ba13-8561bfdf657c"), "Yes", " Gold-plated USB-A", "OUTEMU Blue", "QWERTY", "RGB", "104 Keys with anti-ghosting", "ARYAMAN RGB MECHANICAL Gaming Keyboard – Black", "R3200,00 up to R35000,00", new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"), 8.5999999999999996 }
                });

            migrationBuilder.InsertData(
                table: "GamingLaptops",
                columns: new[] { "GamingLaptopId", "CoolingSystem", "DisplayResolution", "DisplaySize", "GamingLaptopDescription", "Graphics", "HardDisk", "ImgURL", "Name", "OS", "Price", "Processor", "ProductId", "Ram", "Rating", "Weight" },
                values: new object[,]
                {
                    { new Guid("e0b375b3-5e85-4975-858b-bbd6457c4a5d"), "Alienware-inspired thermal design", "FHD, 1920 x 1080, 165 Hz", "15.6-inch", "Modern, sleek and easy to carry. What more could you want? You’ll game in style with this special edition 15-inch laptop featuring a contemporary aluminum cover and iridescent logo. For an even bolder look, choose the optional 4-zone RGB backlit keyboard with WASD which you can control through the Alienware Command Center.", "Nvidia®GeForce® RTX™ 3060, 6 GB, GDDR6 / Integrated: Intel®UHD Graphics", "512 GB, M.2 2280, PCIe NVMe Gen3 x4, SSD", "https://www.flickr.com/photos/196942735@N04/52500430151/in/dateposted-public/", "Dell Inspiron G15 5511", "Windows 11 Pro, 64-bit", "R21000,00 up to R24900,00", "11th Generation Intel® Core™ i7-11800H (24 MB Cache, 8 Core, 2.30 GHz to 4.60 GHz)", new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"), "16 GB, 2 x 8 GB, Dual-Channel DDR4, 3200 MHz", 9.8000000000000007, "2.65kg." },
                    { new Guid("ecc8c004-bcd3-4e50-ad40-3191be9e73e2"), "Exclusive Cooler Boost 5 Technology", "144Hz IPS Full HD (1920x1080)", "15.6-inch", "MSI Sword 15 15.6-inch FHD Laptop - Intel Core i7-12700H 512GB SSD 16GB RAM RTX 3050 Ti Windows 11 Pro SWORD 15 A12UD-474ZA Sword 15 is tailored for those who love RPG games. It's powerful yet sturdy and the blue backlit keyboard is exclusively modulated to provide a distinctive color that will create the best gaming atmosphere for avid gamers.", "RTX 3050 Ti 4GB", "512GB SSD", "https://www.flickr.com/photos/196942735@N04/52501464310/in/dateposted-public/", "MSI Sword 15 15.6-inch FHD Laptop SWORD 15 A12UD-474ZA", "Windows 11 Home", "R21000,00 up to R26000,00", "Intel Core i7-12700H", new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"), "16GB RAM", 9.5999999999999996, "2.25kg." }
                });

            migrationBuilder.InsertData(
                table: "GamingMouses",
                columns: new[] { "GamingMouseId", "Buttons", "Connector", "Lighting", "Name", "PollRate", "Price", "ProductId", "Rating", "Weight" },
                values: new object[,]
                {
                    { new Guid("5caac7fa-86de-41c2-b661-50570d500d2e"), "12 programmable buttons", "Wireless and Wired. IT'S YOUR CHOICE", "ROG Spatha X. Lighting", "ASUS ROG SPATHA GAMING MOUSE", "2000 Hz (wireless), 1000Hz (wired)", "R3200,00 up to R35000,00", new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"), 8.8000000000000007, " 175g" },
                    { new Guid("ed2389ff-3288-43c8-a8d7-d0c91075135e"), "9 User Programmable Buttons, 2 Side Buttons, Rapid Fire Button", "Wireless and Wired. IT'S YOUR CHOICE", "RGB", "SNIPER PRO 16000DPI Wireless RGB Gaming Mouse – Black", "125 – 1 000Hz", "R3200,00 up to R35000,00", new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"), 8.4000000000000004, " 159g" }
                });

            migrationBuilder.InsertData(
                table: "HDDs",
                columns: new[] { "HDDId", "CacheSize", "FormFactor", "Interface", "Name", "Price", "ProductId", "Rating", "StorageCapacity" },
                values: new object[,]
                {
                    { new Guid("7bcf864b-9dac-4c9a-bc93-8c060e5693fc"), "64MB", "3.5 Inch", "SATA III 6 Gb/s", "WD Purple 1TB SATA HDD", "R750,00 up to R900,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 8.6999999999999993, " 1000 GB" },
                    { new Guid("dd32228a-8391-4e0d-ae06-cdb80208c018"), "128MB", "2.5 Inch", "SATA III 6 Gb/s", "Seagate Barracuda ST5000LM000", "R2000,00 up to R2400,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.0, " 5000 GB" }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "LaptopId", "DisplayResolution", "DisplaySize", "Graphics", "HardDisk", "LaptopDescription", "Model", "Name", "OS", "Price", "Processor", "ProductId", "Ram", "Rating", "Weight" },
                values: new object[,]
                {
                    { new Guid("e0b375b3-5e85-4975-858b-bbd6457c4a5d"), "FHD, 1920 x 1080, 165 Hz", "15.6-inch", "Integrated: Intel®UHD Graphics", "1 TB, M.2 2280, PCIe NVMe Gen3 x4, SSD", "Modern, sleek and easy to carry. What more could you want? You’ll game in style with this special edition 15-inch laptop featuring a contemporary aluminum cover and iridescent logo. For an even bolder look, choose the optional 4-zone RGB backlit keyboard with WASD which you can control through the Alienware Command Center.", "G15 5511", "Dell Inspiron G15 5511", "Windows 11 Home, 64-bit", "R15400,00 up to R19000,00", "11th Generation Intel® Core™ i7-11800H (24 MB Cache, 8 Core, 2.30 GHz to 4.60 GHz)", new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"), "16 GB, 2 x 8 GB, Dual-Channel DDR4, 3200 MHz", 9.8000000000000007, "2.65kg." },
                    { new Guid("ecc8c004-bcd3-4e50-ad40-3191be9e73e2"), "144Hz IPS Full HD (1920x1080)", "15.6-inch", "RTX 3050 Ti 8GB", "512GB SSD", "MSI Sword 15 15.6-inch FHD Laptop - Intel Core i7-12700H 512GB SSD 16GB RAM RTX 3050 Ti Windows 11 Pro SWORD 15 A12UD-474ZA Sword 15 is tailored for those who love RPG games. It's powerful yet sturdy and the blue backlit keyboard is exclusively modulated to provide a distinctive color that will create the best gaming atmosphere for avid gamers.", "A12UD-474ZA", "MSI Sword 15 15.6-inch FHD Laptop SWORD 15", "Windows 11 Pro", "R14300,00 up to R18000,00", "Intel Core i7-12700H", new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"), "16GB RAM", 9.5999999999999996, "2.25kg." }
                });

            migrationBuilder.InsertData(
                table: "Motherboards",
                columns: new[] { "MotherboardId", "Chipset", "MoboCPU", "MoboConnectors", "MoboMaxMemory", "MoboUSBPorts", "Name", "PCIExpress", "Price", "ProductId", "Rating" },
                values: new object[,]
                {
                    { new Guid("109c947e-a4f1-4f00-84d9-0a885b89e51c"), "Intel Z690 Express Chipset", "LGA1700", "6x SATA 6Gbps, 3x M.2 Gen4 x4", "4  DIMM SLOTS, Supports Up to 128GB DDR4", "1 x USB 3.2 Gen2 Type-C, 1 x USB 3.2 Gen2 Type-A, 4 x USB 3.2 Gen1 Type-A, 4 x USB 2.0 Type-A", "GIGABYTE Intel Z690 Aorus Elite Motherboard (LGA 1700)", "1x PCI-E 5.0 x16, 2x PCI-E 3.0 x16 Slots", "R1800,00 up to R2500,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.1999999999999993 },
                    { new Guid("1a73ef26-6453-43f4-bdc0-07d0f21fc12a"), "Ready for 2nd and 3rd Gen AMD Ryzen™ processors", " Socket AM4, Compatible processor series", "8x SATA 6Gb/s Ports, 2x M.2 Slots", "Supports up to 128GB Dual Channel DDR4-SDRAM", "1 USB 3.1 G2 Type-A, 1 USB 3.1 G2 Type-C, 4 USB 3.1 G1 Type-A, and 2 USB 2.0 ports", "Asus TUF Gaming X570-Plus (WI-FI) AMD Socket AM4 ATX Wi-Fi 5 Motherboard", "1x PCIe 4.0/3.0 x16, 1x PCIe 3.0/2.0 x16, 2x PCIe 4.0 x1 Slots", "R3200,00 up to R4300,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.4000000000000004 }
                });

            migrationBuilder.InsertData(
                table: "PSUs",
                columns: new[] { "PSUId", "Connectors", "Name", "PlusCertified", "Price", "ProductId", "RatedOutputPower", "Rating" },
                values: new object[,]
                {
                    { new Guid("939f70fe-e1b2-4eef-aa39-e3e592815526"), "24/20-pin x1, CPU 4 + 4 - pin x2, PCI-E 6+2-pin x4, SATA x8, Periplheral x4", "Gigabyte P750GM power supply unit 750 W 20+4 pin ATX Black 80 PLUS Gold, 750W, Active PFC, 120mm", "80Plus Bronze", "R1200,00 up to R1700,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), "750W", 9.5999999999999996 },
                    { new Guid("c9a524a6-a7d6-47e1-b194-7cc43f61928b"), "24/20-pin x1, CPU 4 + 4 - pin x2, PCI-E 6+2-pin x4, SATA x8, Periplheral x4", "Asus TUF Gaming 750W ATX PSU", "80Plus Bronze", "R1200,00 up to R1700,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), "750W", 8.6999999999999993 }
                });

            migrationBuilder.InsertData(
                table: "RAMs",
                columns: new[] { "RAMId", "Name", "Price", "ProductId", "RAMSpeed", "RAMType", "RamCapacity", "Rating" },
                values: new object[,]
                {
                    { new Guid("47a6d393-9834-469f-b77c-d98047874eaf"), "Kingston 32GB 3200MHz DDR4 FURYBeastRGB", "R2200,00 up to R2500,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), "3200 MHz", "DDR4", "32GB", 9.0999999999999996 },
                    { new Guid("bd52bbb4-5ca9-4c20-9c59-f47e6b948c76"), "Corsair Vegeance RS RGB 64GB (2x32GB) DDR4 RAM – 3600MHz", "R3800,00 up to R4400,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), "3600 MHz", "DDR4", "64GB", 9.6999999999999993 }
                });

            migrationBuilder.InsertData(
                table: "Routers",
                columns: new[] { "RouterId", "MU_MIMO", "Name", "Price", "ProductId", "RAM", "Rating", "TransferRate", "WiFiPorts" },
                values: new object[,]
                {
                    { new Guid("558ac570-0e06-49b4-858e-d5b18a2f5b8b"), "Supported", "Xiaomi Mi AIoT Wireless Router AC235012th Generation Intel Core i5 HexaCore Performance Workstation", "R3200,00 up to R3800,00", new Guid("86a3510e-bf98-434e-9685-809b0e5dd36f"), "128MB RAM", 8.8000000000000007, "Wireless speeds of up to 2183Mbps", "4 & a WAN port" },
                    { new Guid("8645c943-f730-4536-9041-a7c190d11142"), "16GB DDR4 RAM @ 3200MHz – open slots for upgrades", "Ubiquiti UniFi Dream Machine", "R11200,00 up to R14000,00", new Guid("86a3510e-bf98-434e-9685-809b0e5dd36f"), "128MB RAM", 8.8000000000000007, "12th Gen Intel® H610 Chipset", "8 & a WAN port" }
                });

            migrationBuilder.InsertData(
                table: "SDDs",
                columns: new[] { "SSDId", "CacheMemory", "FormFactor", "Interface", "Name", "Price", "ProductId", "Rating", "ReadWriteSpeed", "StorageCapacity" },
                values: new object[,]
                {
                    { new Guid("0db44a46-e172-421a-86e6-ddd86832a5f4"), "64MB", "M.2 2280", "PCIe Gen 4.0 x4, NVMe 1.3c", "980 PRO PCle 4.0 NVMe M.2 SSD 1 TB", "R1200,00 up to R1600,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 8.3000000000000007, "Read speed 560 MB/s, Write speed 530 MB/s", " 1024GB" },
                    { new Guid("83dd3c9e-523f-4917-8570-a1678a46445b"), "64MB", "2.5 Inch", "6 Gb/s", "WD Blue 3D 2.5-inch 1TB Serial ATA III Internal SSD WD S100T2B0A", "R1500,00 up to R1800,00", new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"), 9.0, "Read speed 560 MB/s, Write speed 530 MB/s", " 1024GB" }
                });

            migrationBuilder.InsertData(
                table: "SmartPhones",
                columns: new[] { "SmartPhoneId", "BatteryLife", "Camera", "ChargerType", "ImgURL", "Name", "PlatForm", "Price", "Processor", "ProductId", "RAM", "Rating", "ScreenSize", "Sensors", "ShortDescription", "SoftwareVersion", "Storage" },
                values: new object[,]
                {
                    { new Guid("1d71a6e1-7fd9-477c-af92-7fed66ceb7b7"), "4500 mAh", "50MP Wide-angle Camera, 10MP Telephoto Camera, 10MP Selfie Camera", "USB Type-C, 5A charging cable that comes with the 45w charger", "https://www.flickr.com/photos/196942735@N04/52501006961/in/dateposted-public/", "Samsung S22 Plus 5G 256GB Black", "Android", "R18200,00 up to R22000,00", "Octa-core (4x2.8 GHz Kryo 385 Gold & 4x1.8 GHz Kryo 385 Silver)", new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"), "8GB", 9.5999999999999996, "6.6-inch flat FHD+Dynamic AMOLED2X", " Gravity sensor, Ambient light sensor, Proximity sensor, Gyroscope, Compass, fingerprint sensor, ForceTouch sensor, Shark Eye", "The selfie camera on most Samsung flagships is usually superb, and the Galaxy S22 Plus doesn't disappoint here. Superb detail without much over-sharpening, great colors, and excellent subject separation in portrait mode will make you want to take more and more selfies. The 4K 60fps selfie video is also to die for.", "Android 12 (Snow Cone)", "256GB/512GB" },
                    { new Guid("5c2c9eef-978e-4236-a11a-d422658cd693"), "4650mAh battery with 120W charging speed", "Rear Camera: 108MP f/1.75 | Wide-angle: 8MP f/2.2 120° | Macro: 5MP f/2.4, Front Camera: 20MP 4in1 f/2.45", "2.0, Type-C 1.0 reversible connector", "https://www.flickr.com/photos/196942735@N04/52501549218/in/dateposted-public/", "Xiaomi Black Shark 5 Pro", "Android", "R15200,00 up to R17000,00", "Octa-core, 1x 3.00GHz Cortex-X2 + 3x 2.40GHz Cortex-A710 + 4x 1.70GHz Cortex-A510", new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"), "8GB", 9.5, "6.67-inch OLED display with 144Hz refresh rate", " Gravity sensor, Ambient light sensor, Proximity sensor, Gyroscope, Compass, fingerprint sensor, ForceTouch sensor, Shark Eye", "The Xiaomi Black Shark is a gaming phone that comes with 6.67-inch OLED display with 144Hz refresh rate and Qualcomm Snapdragon 8 Gen 1 processor. Specs also include 4650mAh battery with 120W charging speed, Triple camera setup on the back with 108MP main sensor and 16MP front selfie camera.", "Android 12 (Snow Cone)", "256GB, not expandable" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CPUCoolers",
                keyColumn: "CPUCoolerId",
                keyValue: new Guid("71e42e0b-ddce-4b59-95d6-a7ab9328d072"));

            migrationBuilder.DeleteData(
                table: "CPUCoolers",
                keyColumn: "CPUCoolerId",
                keyValue: new Guid("b6589538-2fc1-4912-bf0f-fdbf7279d302"));

            migrationBuilder.DeleteData(
                table: "CPUs",
                keyColumn: "CPUId",
                keyValue: new Guid("76935143-b5db-4acb-9a48-ccc5c437b5c7"));

            migrationBuilder.DeleteData(
                table: "CPUs",
                keyColumn: "CPUId",
                keyValue: new Guid("b02a9311-744f-4e70-8c99-3839e1ab5379"));

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: new Guid("a3b90db4-f3e4-4470-bdce-205907919e2c"));

            migrationBuilder.DeleteData(
                table: "Cases",
                keyColumn: "CaseId",
                keyValue: new Guid("e4148db2-3007-4f27-9cff-46b1caba4545"));

            migrationBuilder.DeleteData(
                table: "Desktops",
                keyColumn: "DesktopId",
                keyValue: new Guid("fa74efcb-8d53-4aae-9e50-0922a48aa250"));

            migrationBuilder.DeleteData(
                table: "Desktops",
                keyColumn: "DesktopId",
                keyValue: new Guid("ff4d2693-e52e-4a72-bec3-8a5ba6143f82"));

            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "DroneId",
                keyValue: new Guid("0afa2038-bb78-4eef-b4c7-b8f29d8801bc"));

            migrationBuilder.DeleteData(
                table: "Drones",
                keyColumn: "DroneId",
                keyValue: new Guid("f49ffbde-38cf-4f2d-b785-7f391cec79aa"));

            migrationBuilder.DeleteData(
                table: "GPUs",
                keyColumn: "GPUId",
                keyValue: new Guid("0f44b6df-908d-4df2-a2ea-d178e7ca5104"));

            migrationBuilder.DeleteData(
                table: "GPUs",
                keyColumn: "GPUId",
                keyValue: new Guid("7262ed78-1189-47fe-8f9d-cd7893ef4912"));

            migrationBuilder.DeleteData(
                table: "GamingConsoles",
                keyColumn: "GamingConsoleId",
                keyValue: new Guid("1364f79a-bb8b-4c91-addc-406f8665cd3c"));

            migrationBuilder.DeleteData(
                table: "GamingConsoles",
                keyColumn: "GamingConsoleId",
                keyValue: new Guid("79ac0bfd-791c-40f5-bb48-371af8833913"));

            migrationBuilder.DeleteData(
                table: "GamingDesktops",
                keyColumn: "GamingDesktopId",
                keyValue: new Guid("289d1c08-bb4a-4c1d-9407-ae43e5cd7797"));

            migrationBuilder.DeleteData(
                table: "GamingDesktops",
                keyColumn: "GamingDesktopId",
                keyValue: new Guid("cf326876-671c-4727-93d7-f0cb27c7a11a"));

            migrationBuilder.DeleteData(
                table: "GamingHeadphonesAndHeadsets",
                keyColumn: "GamingHeadphonesAndHeadsetId",
                keyValue: new Guid("7e9c815e-d538-4118-adfb-c419734e5ec6"));

            migrationBuilder.DeleteData(
                table: "GamingHeadphonesAndHeadsets",
                keyColumn: "GamingHeadphonesAndHeadsetId",
                keyValue: new Guid("d1001f69-46f1-4ba5-b1a7-92e5441d8d4d"));

            migrationBuilder.DeleteData(
                table: "GamingKeyboards",
                keyColumn: "GamingKeyboardId",
                keyValue: new Guid("5b1d1692-3e47-4078-be2e-6008f6163f50"));

            migrationBuilder.DeleteData(
                table: "GamingKeyboards",
                keyColumn: "GamingKeyboardId",
                keyValue: new Guid("edae3ba8-5568-471c-ba13-8561bfdf657c"));

            migrationBuilder.DeleteData(
                table: "GamingLaptops",
                keyColumn: "GamingLaptopId",
                keyValue: new Guid("e0b375b3-5e85-4975-858b-bbd6457c4a5d"));

            migrationBuilder.DeleteData(
                table: "GamingLaptops",
                keyColumn: "GamingLaptopId",
                keyValue: new Guid("ecc8c004-bcd3-4e50-ad40-3191be9e73e2"));

            migrationBuilder.DeleteData(
                table: "GamingMouses",
                keyColumn: "GamingMouseId",
                keyValue: new Guid("5caac7fa-86de-41c2-b661-50570d500d2e"));

            migrationBuilder.DeleteData(
                table: "GamingMouses",
                keyColumn: "GamingMouseId",
                keyValue: new Guid("ed2389ff-3288-43c8-a8d7-d0c91075135e"));

            migrationBuilder.DeleteData(
                table: "HDDs",
                keyColumn: "HDDId",
                keyValue: new Guid("7bcf864b-9dac-4c9a-bc93-8c060e5693fc"));

            migrationBuilder.DeleteData(
                table: "HDDs",
                keyColumn: "HDDId",
                keyValue: new Guid("dd32228a-8391-4e0d-ae06-cdb80208c018"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "LaptopId",
                keyValue: new Guid("e0b375b3-5e85-4975-858b-bbd6457c4a5d"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "LaptopId",
                keyValue: new Guid("ecc8c004-bcd3-4e50-ad40-3191be9e73e2"));

            migrationBuilder.DeleteData(
                table: "Motherboards",
                keyColumn: "MotherboardId",
                keyValue: new Guid("109c947e-a4f1-4f00-84d9-0a885b89e51c"));

            migrationBuilder.DeleteData(
                table: "Motherboards",
                keyColumn: "MotherboardId",
                keyValue: new Guid("1a73ef26-6453-43f4-bdc0-07d0f21fc12a"));

            migrationBuilder.DeleteData(
                table: "PSUs",
                keyColumn: "PSUId",
                keyValue: new Guid("939f70fe-e1b2-4eef-aa39-e3e592815526"));

            migrationBuilder.DeleteData(
                table: "PSUs",
                keyColumn: "PSUId",
                keyValue: new Guid("c9a524a6-a7d6-47e1-b194-7cc43f61928b"));

            migrationBuilder.DeleteData(
                table: "RAMs",
                keyColumn: "RAMId",
                keyValue: new Guid("47a6d393-9834-469f-b77c-d98047874eaf"));

            migrationBuilder.DeleteData(
                table: "RAMs",
                keyColumn: "RAMId",
                keyValue: new Guid("bd52bbb4-5ca9-4c20-9c59-f47e6b948c76"));

            migrationBuilder.DeleteData(
                table: "Routers",
                keyColumn: "RouterId",
                keyValue: new Guid("558ac570-0e06-49b4-858e-d5b18a2f5b8b"));

            migrationBuilder.DeleteData(
                table: "Routers",
                keyColumn: "RouterId",
                keyValue: new Guid("8645c943-f730-4536-9041-a7c190d11142"));

            migrationBuilder.DeleteData(
                table: "SDDs",
                keyColumn: "SSDId",
                keyValue: new Guid("0db44a46-e172-421a-86e6-ddd86832a5f4"));

            migrationBuilder.DeleteData(
                table: "SDDs",
                keyColumn: "SSDId",
                keyValue: new Guid("83dd3c9e-523f-4917-8570-a1678a46445b"));

            migrationBuilder.DeleteData(
                table: "SmartPhones",
                keyColumn: "SmartPhoneId",
                keyValue: new Guid("1d71a6e1-7fd9-477c-af92-7fed66ceb7b7"));

            migrationBuilder.DeleteData(
                table: "SmartPhones",
                keyColumn: "SmartPhoneId",
                keyValue: new Guid("5c2c9eef-978e-4236-a11a-d422658cd693"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1b91027a-738f-4355-909f-edfa6c1d9f2d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("26747c2d-fecb-4769-9134-2d1b9cd09975"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("86a3510e-bf98-434e-9685-809b0e5dd36f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("af0ebf11-47ab-453e-87d3-1dea44afe476"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c96662cb-4ceb-44eb-b1eb-9dee1e94c53b"));
        }
    }
}
