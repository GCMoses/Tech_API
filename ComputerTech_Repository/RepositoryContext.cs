using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_Entities.Tech_Models.Gaming;
using ComputerTechAPI_Entities.Tech_Models.PCComponents;
using ComputerTechAPI_Entities.Tech_Models.Networking;
using ComputerTechAPI_Entities.Tech_Models.PC;
using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using ComputerTechAPI_Entities.Tech_Models.Accessories;
using ComputerTech_Repository.DataConfiguration.GamingDataConfiguration;
using ComputerTech_Repository.DataConfiguration;
using ComputerTech_Repository.DataConfiguration.ComponentDataConfiguration;
using ComputerTech_Repository.DataConfiguration.PCDataConfiguration;

using Microsoft.EntityFrameworkCore;

namespace ComputerTech_Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GamingHeadphonesAndHeadsetDataConfiguration());
        modelBuilder.ApplyConfiguration(new GamingKeyboardDataConfiguration());
        modelBuilder.ApplyConfiguration(new GamingMouseDataConfiguration());
        modelBuilder.ApplyConfiguration(new CaseDataConfiguration());
        modelBuilder.ApplyConfiguration(new CPUCoolerDataConfiguration());
        modelBuilder.ApplyConfiguration(new CPUDataConfiguration());
        modelBuilder.ApplyConfiguration(new HDDDataConfiguration());
        modelBuilder.ApplyConfiguration(new MotherboardDataConfiguration());
        modelBuilder.ApplyConfiguration(new PSUDataConfiguration());
        modelBuilder.ApplyConfiguration(new RAMDataConfiguration());
        modelBuilder.ApplyConfiguration(new SSDDataConfiguration());
        modelBuilder.ApplyConfiguration(new GamingConsoleDataConfiguration());
        modelBuilder.ApplyConfiguration(new GamingDesktopDataConfiguration());
        modelBuilder.ApplyConfiguration(new GamingLaptopDataConfiguration());
        modelBuilder.ApplyConfiguration(new GPUDataConfiguration());
        modelBuilder.ApplyConfiguration(new RouterDataConfiguration());
        modelBuilder.ApplyConfiguration(new DesktopDataConfiguration());
        modelBuilder.ApplyConfiguration(new LaptopDataConfiguration());
        modelBuilder.ApplyConfiguration(new DroneDataConfiguration());
        modelBuilder.ApplyConfiguration(new SmartPhoneDataConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
    }

    public DbSet<GamingHeadphonesAndHeadset>? GamingHeadphonesAndHeadsets { get; set; }
    public DbSet<GamingKeyboard>? GamingKeyboards { get; set; }
    public DbSet<GamingMouse>? GamingMouses { get; set; }
    public DbSet<GamingDesktop>? GamingDesktops { get; set; }
    public DbSet<GamingLaptop>? GamingLaptops { get; set; }
    public DbSet<GPU>? GPUs { get; set; }
    public DbSet<GamingConsole>? GamingConsoles { get; set; }
    public DbSet<Router>? Routers { get; set; }
    public DbSet<Desktop>? Desktops { get; set; }
    public DbSet<Laptop>? Laptops { get; set; }
    public DbSet<SSD>? SDDs { get; set; }
    public DbSet<Case>? Cases { get; set; }
    public DbSet<CPU>? CPUs { get; set; }
    public DbSet<CPUCooler>? CPUCoolers { get; set; }
    public DbSet<HDD>? HDDs { get; set; }
    public DbSet<Motherboard>? Motherboards { get; set; }
    public DbSet<PSU>? PSUs { get; set; }
    public DbSet<RAM>? RAMs { get; set; }
    public DbSet<Drone>? Drones { get; set; }
    public DbSet<SmartPhone>? SmartPhones { get; set; }
    public DbSet<Product>? Products { get; set; }
}
