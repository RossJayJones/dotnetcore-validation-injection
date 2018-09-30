using System;

namespace ValidationInjection.Validation
{
    public class CustomValidationContextProvider
    {
        private CustomValidationContext _context;

        public CustomValidationContext Current
        {
            get
            {
                if (_context == null)
                {
                    throw new InvalidOperationException("The custom validation context has not been initialized. Ensure that the CustomValidationModelBinder is being used.");
                }

                return _context;
            }
        }

        internal void Set(CustomValidationContext context)
        {
            if (_context != null)
            {
                throw new InvalidOperationException("Custom validation context has already been set.");
            }

            _context = context;
        }
    }
}
