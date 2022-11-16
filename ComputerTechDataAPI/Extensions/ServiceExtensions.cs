using ComputerTechAPI_Repository;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_LoggingServices;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.EntityFrameworkCore;
using ComputerTechAPI_Services;

namespace ComputerTechDataAPI.Extensions;

public static class ServiceExtensions
{

    public static void ConfigureCors(this IServiceCollection services) =>
 services.AddCors(options =>
 {
     options.AddPolicy("CorsPolicy", builder =>
     builder.AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
 });


    public static void ConfigureIISIntegration(this IServiceCollection services) =>
 services.Configure<IISOptions>(options =>
 {
 });


    public static void ConfigureLoggerService(this IServiceCollection services) =>
 services.AddSingleton<ILogsManager, LogsManager>();

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
     services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureSqlContext(this IServiceCollection services,
IConfiguration configuration) =>
services.AddDbContext<RepositoryContext>(opts =>
opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

}
