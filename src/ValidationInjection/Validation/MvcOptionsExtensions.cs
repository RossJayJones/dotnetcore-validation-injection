using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace ValidationInjection.Validation
{
    public static class MvcOptionsExtensions
    {
        public static void UseRiskDataModelBindingProvider(this MvcOptions opts)
        {
            var underlyingModelBinder = opts.ModelBinderProviders.FirstOrDefault(x => x.GetType() == typeof(BodyModelBinderProvider));

            if (underlyingModelBinder == null)
            {
                return;
            }

            var index = opts.ModelBinderProviders.IndexOf(underlyingModelBinder);
            opts.ModelBinderProviders.Insert(index, new CustomValidationModelBinderProvider(underlyingModelBinder));
        }
    }
}
