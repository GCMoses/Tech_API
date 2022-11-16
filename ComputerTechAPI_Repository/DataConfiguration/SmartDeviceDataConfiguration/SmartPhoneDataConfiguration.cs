using ComputerTechAPI_Entities.Tech_Models.SmartDevices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ComputerTechAPI_Repository.DataConfiguration;

public class SmartPhoneDataConfiguration : IEntityTypeConfiguration<SmartPhone>
{
    public void Configure(EntityTypeBuilder<SmartPhone> builder)
    {
        builder.HasData
        (
        new SmartPhone
        {
            Id = new Guid("5c2c9eef-978e-4236-a11a-d422658cd693"),
            Name = "Xiaomi Black Shark 5 Pro",
            ImgURL = "https://www.flickr.com/photos/196942735@N04/52501549218/in/dateposted-public/",
            BatteryLife = "4650mAh battery with 120W charging speed",
            Processor = "Octa-core, 1x 3.00GHz Cortex-X2 + 3x 2.40GHz Cortex-A710 + 4x 1.70GHz Cortex-A510",
            PlatForm = "Android",
            Storage = "256GB, not expandable",
            RAM = "8GB",
            Camera = "Rear Camera: 108MP f/1.75 | Wide-angle: 8MP f/2.2 120° | Macro: 5MP f/2.4, Front Camera: 20MP 4in1 f/2.45",
            SoftwareVersion = "Android 12 (Snow Cone)",
            Sensors = " Gravity sensor, Ambient light sensor, Proximity sensor, Gyroscope, Compass, fingerprint sensor, ForceTouch sensor, Shark Eye",
            ScreenSize = "6.67-inch OLED display with 144Hz refresh rate",
            ChargerType = "2.0, Type-C 1.0 reversible connector",
            ShortDescription = "The Xiaomi Black Shark is a gaming phone that comes with 6.67-inch OLED display with 144Hz refresh rate and Qualcomm Snapdragon 8 Gen 1 processor. Specs also include 4650mAh battery with 120W charging speed, Triple camera setup on the back with 108MP main sensor and 16MP front selfie camera.",
            Price = "R15200,00 up to R17000,00",
            Rating = 9.5,
            ProductId = new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb"),

        },
        new SmartPhone
        {
            Id = new Guid("1d71a6e1-7fd9-477c-af92-7fed66ceb7b7"),
            Name = "Samsung S22 Plus 5G 256GB Black",
            ImgURL = "https://www.flickr.com/photos/196942735@N04/52501006961/in/dateposted-public/",
            BatteryLife = "4500 mAh",
            Processor = "Octa-core (4x2.8 GHz Kryo 385 Gold & 4x1.8 GHz Kryo 385 Silver)",
            PlatForm = "Android",
            Storage = "256GB/512GB",
            RAM = "8GB",
            Camera = "50MP Wide-angle Camera, 10MP Telephoto Camera, 10MP Selfie Camera",
            SoftwareVersion = "Android 12 (Snow Cone)",
            Sensors = " Gravity sensor, Ambient light sensor, Proximity sensor, Gyroscope, Compass, fingerprint sensor, ForceTouch sensor, Shark Eye",
            ScreenSize = "6.6-inch flat FHD+Dynamic AMOLED2X",
            ChargerType = "USB Type-C, 5A charging cable that comes with the 45w charger",
            Price = "R18200,00 up to R22000,00",
            ShortDescription = "The selfie camera on most Samsung flagships is usually superb, and the Galaxy S22 Plus doesn't disappoint here. Superb detail without much over-sharpening, great colors, and excellent subject separation in portrait mode will make you want to take more and more selfies. The 4K 60fps selfie video is also to die for.",
            Rating = 9.6,
            ProductId = new Guid("662ce63f-fd4b-44db-b8b4-9a9d2cac9aeb")
        }
      );
    }
}
