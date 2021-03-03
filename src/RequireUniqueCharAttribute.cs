namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequireUniqueCharAttribute : ValidationAttribute
    {
        public RequireUniqueCharAttribute()
            : base(() => "Unique character is required")
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            if (value is string actual)
            {
                var array = new bool[256]; // or longer for unicode
                foreach (var c in actual)
                {
                    if (array[c])
                        return false;
                    array[c] = true;
                }
                return true;
            }
            return false;
        }
    }
}