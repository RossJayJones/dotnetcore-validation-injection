using System.Threading.Tasks;

namespace ValidationInjection.Validation
{
    public class CustomValidationContextFactory
    {
        /// <summary>
        /// Simulates a call which would typically get data from a database or some service call.
        /// The key here is that this operation would need to be executed asynchronously.
        /// </summary>
        /// <returns></returns>
        public Task<CustomValidationContext> Create()
        {
            return Task.FromResult(new CustomValidationContext(new [] { "a", "b", "c" }, new[] {"1", "2", "3"}));
        }
    }
}
