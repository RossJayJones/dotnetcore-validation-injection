using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ValidationInjection.Validation
{
    public class CustomValidationModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinderProvider _underlyingModelBinderProvider;

        public CustomValidationModelBinderProvider(IModelBinderProvider underlyingModelBinderProvider)
        {
            _underlyingModelBinderProvider = underlyingModelBinderProvider;
        }


        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var underlyingModelBinderProvider = _underlyingModelBinderProvider.GetBinder(context);
            return new CustomValidationModelBinder(underlyingModelBinderProvider);
        }
    }
}
