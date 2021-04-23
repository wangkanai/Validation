namespace System.ComponentModel.DataAnnotations
{
    public class RequireFalseAttribute : ValidationAttribute
    {
        public RequireFalseAttribute()
            : base(() => "Unchecked is required")
        {
        }

        public override bool IsValid(object value) =>
            value switch
            {
                null        => true,
                bool actual => actual == false,
                _           => false
            };
    }
}