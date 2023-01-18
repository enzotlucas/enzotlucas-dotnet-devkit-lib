using enzotlucas.DevKit.Core.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace enzotlucas.DevKit.DependencyInjection.Validator
{
    /// <summary>
    /// 
    /// </summary>
    public static class ValidatorEntensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
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
