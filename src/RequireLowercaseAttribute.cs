using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequireLowercaseAttribute : ValidationAttribute
    {
        public RequireLowercaseAttribute()
            : base(() => "Lowercase is required")
        {
        }

        public override bool IsValid(object value) =>
            value switch
            {
                null          => true, // Required duty
                string actual => actual.Any(char.IsLower),
                _             => false
            };
    }
}