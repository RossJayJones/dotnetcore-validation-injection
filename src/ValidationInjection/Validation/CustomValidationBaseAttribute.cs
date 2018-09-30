using System;
using System.ComponentModel.DataAnnotations;

namespace ValidationInjection.Validation
{
    public abstract class CustomValidationBaseAttribute : ValidationAttribute
    {
        protected sealed override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customValidationContextProvider = (CustomValidationContextProvider)validationContext.GetService(typeof(CustomValidationContextProvider));

            if (customValidationContextProvider == null)
            {
                throw new InvalidOperationException("The custom validation context provider has not been registered");
            }

            return IsValid(value, customValidationContextProvider.Current, validationContext);
        }

        protected abstract ValidationResult IsValid(object value, CustomValidationContext customValidationContext, ValidationContext validationContext);
    }
}
