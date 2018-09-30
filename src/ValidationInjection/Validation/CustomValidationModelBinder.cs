using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ValidationInjection.Validation
{
    public class CustomValidationModelBinder : IModelBinder
    {
        private readonly IModelBinder _underlyingModelBinder;

        public CustomValidationModelBinder(IModelBinder underlyingModelBinder)
        {
            _underlyingModelBinder = underlyingModelBinder;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            await _underlyingModelBinder.BindModelAsync(bindingContext).ConfigureAwait(false);

            // If model binding failed don't continue
            if (bindingContext.Result.Model == null)
            {
                return;
            }

            // Wire up the validation context using async methods
            var customValidationContextFactory = (CustomValidationContextFactory)bindingContext.HttpContext.RequestServices.GetService(typeof(CustomValidationContextFactory));
            var customValidationContextProvider = (CustomValidationContextProvider)bindingContext.HttpContext.RequestServices.GetService(typeof(CustomValidationContextProvider));
            var customValidationContext = await customValidationContextFactory.Create();
            customValidationContextProvider.Set(customValidationContext);
        }
    }
}
