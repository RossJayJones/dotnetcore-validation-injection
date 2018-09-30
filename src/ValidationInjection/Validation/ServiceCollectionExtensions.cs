using Microsoft.Extensions.DependencyInjection;

namespace ValidationInjection.Validation
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomValidation(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(CustomValidationContextFactory), typeof(CustomValidationContextFactory), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(CustomValidationContextProvider), typeof(CustomValidationContextProvider), ServiceLifetime.Scoped));
        }
    }
}
