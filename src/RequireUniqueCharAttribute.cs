using System.Collections.Generic;
using System.Linq;

namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequireUniqueCharAttribute : ValidationAttribute
    {
        public int Minimum { get; }

        public RequireUniqueCharAttribute(int minimum = 1)
            : base(() => $"{minimum} unique characters are required")
        {
            Minimum = minimum;
        }

        public override bool IsValid(object value) =>
            value switch
            {
                null          => true,
                string actual => Unique(actual).Count >= Minimum,
                _             => false
            };

        private Dictionary<char, int> Unique(string value)
        {
            var array = new byte[256]; // or longer for unicode
            foreach (var c in value)
                array[c]++;

            var unique = new Dictionary<char, int>();

            for (var i = 0; i < array.Length; i++)
                if (array[i] > 0)
                    unique.Add((char) i, array[i]);

            return unique;
        }
    }
}