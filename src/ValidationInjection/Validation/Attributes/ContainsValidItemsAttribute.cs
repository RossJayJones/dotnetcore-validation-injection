using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationInjection.Validation.Attributes
{
    public class ContainsValidItemsAttribute : CustomValidationBaseAttribute
    {
        protected override ValidationResult IsValid(object value, CustomValidationContext customValidationContext,
            ValidationContext validationContext)
        {
            if (value is ICollection<string> items && items.Any(item => !customValidationContext.ValidItems.Contains(item)))
            {
                return new ValidationResult($"Items contains invalid values. It must be any of {string.Join(", ", customValidationContext.ValidItems)}");
            }

            return ValidationResult.Success;
        }
    }
}
