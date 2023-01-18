using enzotlucas.DevKit.Extensions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace enzotlucas.DevKit.ApiSpecification.Swagger
{
    internal sealed class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;
        private readonly IConfiguration _configuration;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider,
                                       IConfiguration configuration)
        {
            _provider = provider;
            _configuration = configuration;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, _configuration));
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description,
                                                   IConfiguration configuration)
        {
            try
            {
                return TryCreateInfoForApiVersion(description, configuration);
            }
            catch (Exception)
            {
                ConsoleExtensions.PrintError("enzotlucas.DevKit.ApiSpecification.Swagger: Invalid swagger information on configuration file, read the oficial nuget documentation to use the library at full potential");

                return CreateInfoWithUndefinedInformations(description);
            }
        }

        private static OpenApiInfo TryCreateInfoForApiVersion(ApiVersionDescription description,
                                                             IConfiguration configuration)
        {
            if (!configuration.GetSection("Swagger").Exists())
            {
                return CreateInfoWithUndefinedInformations(description);
            }

            return CreateInfoWithDefinedInformations(description, configuration);
        }

        private static OpenApiInfo CreateInfoWithUndefinedInformations(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = Assembly.GetEntryAssembly().GetName().Name,
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
                info.Description += " This version is deprecated!";

            return info;
        }

        static OpenApiInfo CreateInfoWithDefinedInformations(ApiVersionDescription description,
                                                             IConfiguration configuration)
        {
            var info = new OpenApiInfo()
            {
                Title = configuration.GetValue<string>("Swagger:Title"),
                Version = description.ApiVersion.ToString(),
                Description = configuration.GetValue<string>("Swagger:Description"),
                Contact = new OpenApiContact()
                {
                    Name = configuration.GetValue<string>("Swagger:Contact:Name"),
                    Email = configuration.GetValue<string>("Swagger:Contact:Email")
                },
                License = new OpenApiLicense()
                {
                    Name = configuration.GetValue<string>("Swagger:License:Name"),
                    Url = new Uri(configuration.GetValue<string>("Swagger:License:Url"))
                }
            };

            if (description.IsDeprecated)
                info.Description += " This version is deprecated!";

            return info;
        }
    }
}