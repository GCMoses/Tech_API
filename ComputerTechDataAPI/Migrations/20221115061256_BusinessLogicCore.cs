using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComputerTechDataAPI.Migrations
{
    public partial class BusinessLogicCore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriveBays = table.Column<int>(type: "int", nullable: false),
                    ExpansionSlots = table.Column<int>(type: "int", nullable: false),
                    FanSupport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPULenghtLimit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NetWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Cases_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUCoolers",
                columns: table => new
                {
                    CPUCoolerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuiltInFan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Radiator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxFanNoiseLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PWMSupport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxAirflow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfFans = table.Column<int>(type: "int", nullable: false),
                    SocketSupport = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCoolers", x => x.CPUCoolerId);
                    table.ForeignKey(
                        name: "FK_CPUCoolers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    CPUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseClock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoostClock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HyperThreading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpuTDP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cache = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.CPUId);
                    table.ForeignKey(
                        name: "FK_CPUs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desktops",
                columns: table => new
                {
                    DesktopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HardDisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesktopPCDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desktops", x => x.DesktopId);
                    table.ForeignKey(
                        name: "FK_Desktops_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    DroneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemoteController = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Camera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryLife = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.DroneId);
                    table.ForeignKey(
                        name: "FK_Drones_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamingConsoles",
                columns: table => new
                {
                    GamingConsoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiskDrive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolutionAndFrameRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HardDisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingConsoles", x => x.GamingConsoleId);
                    table.ForeignKey(
                        name: "FK_GamingConsoles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamingDesktops",
                columns: table => new
                {
                    GamingDesktopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamingCase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoolingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HardDisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PSU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamingPCDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingDesktops", x => x.GamingDesktopId);
                    table.ForeignKey(
                        name: "FK_GamingDesktops_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamingHeadphonesAndHeadsets",
                columns: table => new
                {
                    GamingHeadphonesAndHeadsetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Connector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Compatability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foldability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingHeadphonesAndHeadsets", x => x.GamingHeadphonesAndHeadsetId);
                    table.ForeignKey(
                        name: "FK_GamingHeadphonesAndHeadsets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamingKeyboards",
                columns: table => new
                {
                    GamingKeyboardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matrix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Connector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeyboardLayout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lighting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeySwitches = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdjustableHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingKeyboards", x => x.GamingKeyboardId);
                    table.ForeignKey(
                        name: "FK_GamingKeyboards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamingLaptops",
                columns: table => new
                {
                    GamingLaptopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplaySize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HardDisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoolingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamingLaptopDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingLaptops", x => x.GamingLaptopId);
                    table.ForeignKey(
                        name: "FK_GamingLaptops_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamingMouses",
                columns: table => new
                {
                    GamingMouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PollRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Connector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Buttons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lighting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamingMouses", x => x.GamingMouseId);
                    table.ForeignKey(
                        name: "FK_GamingMouses_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    GPUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPUClock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VRAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoolingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DXVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUs", x => x.GPUId);
                    table.ForeignKey(
                        name: "FK_GPUs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HDDs",
                columns: table => new
                {
                    HDDId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CacheSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDDs", x => x.HDDId);
                    table.ForeignKey(
                        name: "FK_HDDs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    LaptopId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplaySize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HardDisk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Graphics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaptopDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.LaptopId);
                    table.ForeignKey(
                        name: "FK_Laptops_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    MotherboardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoboCPU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoboMaxMemory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCIExpress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoboUSBPorts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoboConnectors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.MotherboardId);
                    table.ForeignKey(
                        name: "FK_Motherboards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSUs",
                columns: table => new
                {
                    PSUId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatedOutputPower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlusCertified = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Connectors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSUs", x => x.PSUId);
                    table.ForeignKey(
                        name: "FK_PSUs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RAMs",
                columns: table => new
                {
                    RAMId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RamCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMs", x => x.RAMId);
                    table.ForeignKey(
                        name: "FK_RAMs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routers",
                columns: table => new
                {
                    RouterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WiFiPorts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MU_MIMO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routers", x => x.RouterId);
                    table.ForeignKey(
                        name: "FK_Routers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SDDs",
                columns: table => new
                {
                    SSDId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadWriteSpeed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CacheMemory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SDDs", x => x.SSDId);
                    table.ForeignKey(
                        name: "FK_SDDs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmartPhones",
                columns: table => new
                {
                    SmartPhoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatteryLife = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScreenSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Camera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sensors = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChargerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftwareVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartPhones", x => x.SmartPhoneId);
                    table.ForeignKey(
                        name: "FK_SmartPhones_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ProductId",
                table: "Cases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUCoolers_ProductId",
                table: "CPUCoolers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_ProductId",
                table: "CPUs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Desktops_ProductId",
                table: "Desktops",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Drones_ProductId",
                table: "Drones",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingConsoles_ProductId",
                table: "GamingConsoles",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingDesktops_ProductId",
                table: "GamingDesktops",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingHeadphonesAndHeadsets_ProductId",
                table: "GamingHeadphonesAndHeadsets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingKeyboards_ProductId",
                table: "GamingKeyboards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingLaptops_ProductId",
                table: "GamingLaptops",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GamingMouses_ProductId",
                table: "GamingMouses",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_ProductId",
                table: "GPUs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDs_ProductId",
                table: "HDDs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_ProductId",
                table: "Laptops",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ProductId",
                table: "Motherboards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_ProductId",
                table: "PSUs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RAMs_ProductId",
                table: "RAMs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Routers_ProductId",
                table: "Routers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SDDs_ProductId",
                table: "SDDs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartPhones_ProductId",
                table: "SmartPhones",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "CPUCoolers");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "Desktops");

            migrationBuilder.DropTable(
                name: "Drones");

            migrationBuilder.DropTable(
                name: "GamingConsoles");

            migrationBuilder.DropTable(
                name: "GamingDesktops");

            migrationBuilder.DropTable(
                name: "GamingHeadphonesAndHeadsets");

            migrationBuilder.DropTable(
                name: "GamingKeyboards");

            migrationBuilder.DropTable(
                name: "GamingLaptops");

            migrationBuilder.DropTable(
                name: "GamingMouses");

            migrationBuilder.DropTable(
                name: "GPUs");

            migrationBuilder.DropTable(
                name: "HDDs");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "PSUs");

            migrationBuilder.DropTable(
                name: "RAMs");

            migrationBuilder.DropTable(
                name: "Routers");

            migrationBuilder.DropTable(
                name: "SDDs");

            migrationBuilder.DropTable(
                name: "SmartPhones");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
