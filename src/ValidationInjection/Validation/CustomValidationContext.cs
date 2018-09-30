using System.Collections.Generic;

namespace ValidationInjection.Validation
{
    public class CustomValidationContext
    {
        public CustomValidationContext(ICollection<string> validNames, 
            ICollection<string> validItems)
        {
            ValidNames = validNames;
            ValidItems = validItems;
        }

        public ICollection<string> ValidNames { get; }

        public ICollection<string> ValidItems { get; }
    }
}
