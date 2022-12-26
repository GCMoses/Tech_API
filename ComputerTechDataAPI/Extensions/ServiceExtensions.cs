using ComputerTechAPI_Repository;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_LoggingServices;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.EntityFrameworkCore;
using ComputerTechAPI_Services;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using ComputerTechAPI_RequestActions.Controllers;
using Marvin.Cache.Headers;
using AspNetCoreRateLimit;
using ComputerTechAPI_Entities.Tech_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ComputerTechAPI_Entities.ConfigurationModels;
using Microsoft.OpenApi.Models;

namespace ComputerTechDataAPI.Extensions;

public static class ServiceExtensions
{

    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("X-Pagination"));
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



    public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
         builder.AddMvcOptions(config => config.OutputFormatters.Add(new
        CSVOutputFormatter()));


    public static void AddCustomMediaTypes(this IServiceCollection services)
    {
        services.Configure<MvcOptions>(config =>
        {
            var systemTextJsonOutputFormatter = config.OutputFormatters
            .OfType<SystemTextJsonOutputFormatter>()?.FirstOrDefault();
            if (systemTextJsonOutputFormatter != null)
            {
                systemTextJsonOutputFormatter.SupportedMediaTypes
                .Add("application/vnd.lordaizen.hateoas+json");
                systemTextJsonOutputFormatter.SupportedMediaTypes
                .Add("application/vnd.lordaizen.apiroot+json");

            }
            var xmlOutputFormatter = config.OutputFormatters
            .OfType<XmlDataContractSerializerOutputFormatter>()?
            .FirstOrDefault();
            if (xmlOutputFormatter != null)
            {
                xmlOutputFormatter.SupportedMediaTypes
                .Add("application/vnd.lordaizen.hateoas+xml");
                xmlOutputFormatter.SupportedMediaTypes
                .Add("application/vnd.lordaizen.apiroot+xml");
            }
        });
    }



    public static void ConfigureVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(opt =>
        {
            opt.ReportApiVersions = true;
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.ApiVersionReader = new HeaderApiVersionReader("api-version");
            opt.Conventions.Controller<ProductsController>()
                .HasApiVersion(new ApiVersion(1, 0));
            opt.Conventions.Controller<ProductsV2Controller>()
                .HasDeprecatedApiVersion(new ApiVersion(2, 0));
        });
    }


    public static void ConfigureResponseCaching(this IServiceCollection services) => services.AddResponseCaching();

    public static void ConfigureHttpCacheHeaders(this IServiceCollection services) =>
        services.AddHttpCacheHeaders((expirationOpt) =>
        {
            expirationOpt.MaxAge = 65;
            expirationOpt.CacheLocation = CacheLocation.Private;
        },
        (validationOpt) =>
        {
            validationOpt.MustRevalidate = true;
        });


    public static void ConfigureRateLimitingOptions(this IServiceCollection services)
    {
        var rateLimitRules = new List<RateLimitRule>
        {
            new RateLimitRule
                {
                Endpoint = "*",
                Limit = 3,
                Period = "5m"
                }
        };
        services.Configure<IpRateLimitOptions>(opt =>
            {
                opt.GeneralRules = rateLimitRules;
            });
        services.AddSingleton<IRateLimitCounterStore,
        MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
    }


    public static void ConfigureIdentity(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User, IdentityRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 8;
            o.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddDefaultTokenProviders();
    }


    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfiguration = new JwtConfiguration();
        configuration.Bind(jwtConfiguration.Section, jwtConfiguration);
        var secretKey = Environment.GetEnvironmentVariable("BONGOMAN");
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtConfiguration.ValidIssuer,
                ValidAudience = jwtConfiguration.ValidAudience,
                IssuerSigningKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });
    }


    public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration) =>
                       services.Configure<JwtConfiguration>(configuration.GetSection("JwtSettings"));


    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lord Aizen Tech Data API",
                Version = "v1",
                Description = "ComputerTechDataAPI API by LordAizen",
              //TermsOfService = new Uri("https://willcreateonesoon.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Gilmore Moses",
                    Email = "gilmorem78@gmail.com",
                    Url = new Uri("https://lordaizen151.bsite.net/"),
                }
            //    },
            //    License = new OpenApiLicense
            //    {
            //        Name = "Tech API LICX",
            //        Url = new Uri("https://willcreateonesoon.com/license"),
            //    }
            });
            s.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "Lord Aizen API",
                Version = "v2"
            });
            var xmlFile = $"{typeof(ComputerTechAPI_RequestActions.AssemblyReference).Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            s.IncludeXmlComments(xmlPath);
            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Place to add JWT with Bearer",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            s.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                 {
                     new OpenApiSecurityScheme
                     {
                         Reference = new OpenApiReference
                         {
                           Type = ReferenceType.SecurityScheme,
                           Id = "Bearer"
                         },
                        Name = "Bearer",
                     },
                     new List<string>()
                 }
            });
        });
    }
}
