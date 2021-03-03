namespace System.ComponentModel.DataAnnotations
{
    public class RequireTrueAttribute : ValidationAttribute
    {
        public RequireTrueAttribute()
            : base(() => "Checked is required")
        {
        }

        public override bool IsValid(object value) =>
            value switch
            {
                null        => true,
                bool actual => actual,
                _           => false
            };
    }
}