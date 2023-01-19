using enzotlucas.DevKit.Core.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace enzotlucas.DevKit.DependencyInjection.Validator
{
    /// <summary>
    /// Class responsable for dependency injection of the custom request validation pipeline.
    /// </summary>
    public static class ValidatorEntensions
    {
        /// <summary>
        /// Adds the custom request validation pipeline.
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <returns>The <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddDevKitRequestValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining(typeof(UseCasesValidationBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UseCasesValidationBehavior<,>));

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US");

            return services;
        }
    }
}
