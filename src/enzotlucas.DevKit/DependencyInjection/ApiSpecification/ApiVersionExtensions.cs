﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace enzotlucas.DevKit.ApiSpecification
{
    public static class ApiVersionExtensions
    {
        public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
