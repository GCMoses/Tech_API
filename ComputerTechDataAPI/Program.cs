using AspNetCoreRateLimit;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_Contracts.ILinks.IAccessoriesLinks;
using ComputerTechAPI_Contracts.ILinks.IGamingLinks;
using ComputerTechAPI_Contracts.ILinks.INetworkingLinks;
using ComputerTechAPI_Contracts.ILinks.IPCComponentLinks;
using ComputerTechAPI_Contracts.ILinks.IPCLinks;
using ComputerTechAPI_Contracts.ILinks.ISMartDevicesLinks;
using ComputerTechAPI_DtoAndFeatures.DTO.AccessoriesDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.GamingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.NetworkingDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCComponentsDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.PCDTO;
using ComputerTechAPI_DtoAndFeatures.DTO.SmartDevicesDTO;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_Services.DataShaping;
using ComputerTechDataAPI.Extensions;
using ComputerTechDataAPI.TechUtilities.AccessoriesUtilities;
using ComputerTechDataAPI.TechUtilities.GamingUtilities;
using ComputerTechDataAPI.TechUtilities.NetworkingUtilities;
using ComputerTechDataAPI.TechUtilities.PCUtilities;
using ComputerTechDataAPI.TechUtilities.SmartDevicesUtilities;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using NLog;
var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.development.config"));
// Configure services
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.ConfigureVersioning();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureHttpCacheHeaders();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.ConfigureSwagger();



builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<ValidateMediaTypeAttribute>();
//Accessories Shaper
builder.Services.AddScoped<IDataShaper<GamingHeadphonesAndHeadsetDTO>, DataShaper<GamingHeadphonesAndHeadsetDTO>>();
builder.Services.AddScoped<IDataShaper<GamingKeyboardDTO>, DataShaper<GamingKeyboardDTO>>();
builder.Services.AddScoped<IDataShaper<GamingMouseDTO>, DataShaper<GamingMouseDTO>>();
//Gaming Shaper
builder.Services.AddScoped<IDataShaper<GamingConsoleDTO>, DataShaper<GamingConsoleDTO>>();
builder.Services.AddScoped<IDataShaper<GamingDesktopDTO>, DataShaper<GamingDesktopDTO>>();
builder.Services.AddScoped<IDataShaper<GamingLaptopDTO>, DataShaper<GamingLaptopDTO>>();
//Networking Shaper
builder.Services.AddScoped<IDataShaper<RouterDTO>, DataShaper<RouterDTO>>();
//PC Shaper
builder.Services.AddScoped<IDataShaper<DesktopDTO>, DataShaper<DesktopDTO>>();
builder.Services.AddScoped<IDataShaper<LaptopDTO>, DataShaper<LaptopDTO>>();
//PCComponent Shaper
builder.Services.AddScoped<IDataShaper<CaseDTO>, DataShaper<CaseDTO>>();
builder.Services.AddScoped<IDataShaper<CPUDTO>, DataShaper<CPUDTO>>();
builder.Services.AddScoped<IDataShaper<CPUCoolerDTO>, DataShaper<CPUCoolerDTO>>();
builder.Services.AddScoped<IDataShaper<GPUDTO>, DataShaper<GPUDTO>>();
builder.Services.AddScoped<IDataShaper<HDDDTO>, DataShaper<HDDDTO>>();
builder.Services.AddScoped<IDataShaper<MotherboardDTO>, DataShaper<MotherboardDTO>>();
builder.Services.AddScoped<IDataShaper<PSUDTO>, DataShaper<PSUDTO>>();
builder.Services.AddScoped<IDataShaper<RAMDTO>, DataShaper<RAMDTO>>();
builder.Services.AddScoped<IDataShaper<SSDDTO>, DataShaper<SSDDTO>>();
//Smart Devices Shaper
builder.Services.AddScoped<IDataShaper<DroneDTO>, DataShaper<DroneDTO>>();
builder.Services.AddScoped<IDataShaper<SmartPhoneDTO>, DataShaper<SmartPhoneDTO>>();

//Link Accessories
builder.Services.AddScoped<IGamingHeadphonesAndHeadsetLinks, GamingHeadphonesAndHeadsetLinks>();
builder.Services.AddScoped<IGamingKeyboardLinks, GamingKeyboardLinks>();
builder.Services.AddScoped<IGamingMouseLinks, GamingMouseLinks>();
//Link Gaming
builder.Services.AddScoped<IGamingConsoleLinks, GamingConsoleLinks>();
builder.Services.AddScoped<IGamingDesktopLinks, GamingDesktopLinks>();
builder.Services.AddScoped<IGamingLaptopLinks, GamingLaptopLinks>();
//Link Networking
builder.Services.AddScoped<IRouterLinks, RouterLinks>();
//Link PC
builder.Services.AddScoped<IDesktopLinks, DesktopLinks>();
builder.Services.AddScoped<ILaptopLinks, LaptopLinks>();
//Link PCComponents
builder.Services.AddScoped<ICaseLinks, CaseLinks>();
builder.Services.AddScoped<ICPULinks, CPULinks>();
builder.Services.AddScoped<ICPUCoolerLinks, CPUCoolerLinks>();
builder.Services.AddScoped<IGPULinks, GPULinks>();
builder.Services.AddScoped<IHDDLinks, HDDLinks>();
builder.Services.AddScoped<IMotherboardLinks, MotherboardLinks>();
builder.Services.AddScoped<IPSULinks, PSULinks>();
builder.Services.AddScoped<IRAMLinks, RAMLinks>();
builder.Services.AddScoped<ISSDLinks, SSDLinks>();
//LinkSmart Devices
builder.Services.AddScoped<IDroneLinks, DroneLinks>();
builder.Services.AddScoped<ISmartPhoneLinks, SmartPhoneLinks>();

builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication();





builder.Services.AddControllers(config => 
    {
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
    config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
        {
            Duration =120
        });    
    }).AddXmlDataContractSerializerFormatters()
  .AddCustomCSVFormatter()
  .AddApplicationPart(typeof(ComputerTechAPI_RequestActions.AssemblyReference).Assembly);

builder.Services.AddCustomMediaTypes();

var app = builder.Build();

// Configure the HTTP request pipeline.

var logger = app.Services.GetRequiredService<ILogsManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
    app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseIpRateLimiting();
app.UseCors("CorsPolicy");
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "Lord Aizen API v1");
    s.SwaggerEndpoint("/swagger/v2/swagger.json", "Lord Aizen API v2");
});
app.MapControllers();
app.Run();

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
    new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
    .Services.BuildServiceProvider()
    .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
    .OfType<NewtonsoftJsonPatchInputFormatter>().First();