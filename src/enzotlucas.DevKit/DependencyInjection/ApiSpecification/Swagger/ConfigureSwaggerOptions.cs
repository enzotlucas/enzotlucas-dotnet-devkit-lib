using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace enzotlucas.DevKit.ApiSpecification.Swagger
{
    public sealed class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
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

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description,
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