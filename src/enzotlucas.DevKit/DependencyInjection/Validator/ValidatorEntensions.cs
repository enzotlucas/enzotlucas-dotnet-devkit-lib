using enzotlucas.DevKit.Core.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace enzotlucas.DevKit.DependencyInjection.Validator
{
    public static class ValidatorEntensions
    {
        public static IServiceCollection AddDevKitValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining(typeof(UseCasesValidationBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UseCasesValidationBehavior<,>));

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US");

            return services;
        }
    }
}
