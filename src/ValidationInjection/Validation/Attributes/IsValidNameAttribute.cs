using System.ComponentModel.DataAnnotations;

namespace ValidationInjection.Validation.Attributes
{
    public class IsValidNameAttribute : CustomValidationBaseAttribute
    {
        protected override ValidationResult IsValid(object value, CustomValidationContext customValidationContext,
            ValidationContext validationContext)
        {
            var name = value as string;

            if (!string.IsNullOrEmpty(name) && !customValidationContext.ValidNames.Contains(name))
            {
                return new ValidationResult($"{name} is an invalid value. It must be one of {string.Join(", ", customValidationContext.ValidNames)}");
            }

            return ValidationResult.Success;
        }
    }
}