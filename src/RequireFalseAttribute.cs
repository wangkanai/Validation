namespace System.ComponentModel.DataAnnotations
{
    public class RequireFalseAttribute : ValidationAttribute
    {
        public RequireFalseAttribute()
            : base(() => "Unchecked is required")
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            if (value is bool actual)
                return actual == false;

            return false;
        }
    }
}