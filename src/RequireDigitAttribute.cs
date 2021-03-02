﻿using System.Linq;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequireDigitAttribute : ValidationAttribute
    {
        public RequireDigitAttribute()
            : base(() => "Digit is required")
        {
        }

        public override bool IsValid(object value) =>
            value switch
            {
                null          => true,
                string actual => actual.Any(char.IsDigit),
                _             => false
            };
    }
}