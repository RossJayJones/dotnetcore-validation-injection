using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationInjection.Validation.Attributes;

namespace ValidationInjection.Models
{
    public class ValuesModel
    {
        [Required]
        [IsValidName]
        public string Name { get; set; }

        [Required]
        [ContainsValidItems]
        public List<string> Items { get; set; }
    }
}
