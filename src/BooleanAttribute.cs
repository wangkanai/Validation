using System;
using System.ComponentModel.DataAnnotations;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class BooleanAttribute : ValidationAttribute
    {
        public bool Expected { get; }

        public BooleanAttribute(bool expected)
            : base(() => "Boolean actual is not equal to expected.")
        {
            Expected = expected;
        }


        public override bool IsValid(object value) =>
            value switch
            {
                null        => true,
                bool actual => actual == Expected,
                _           => false
            };
    }
}