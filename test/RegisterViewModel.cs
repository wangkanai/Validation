using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Wangkanai.Validation.Tests
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RequireDigit]
        [RequireLowercase]
        [RequireUppercase]
        [RequireNonAlphanumeric]
        [RequireUniqueChar]
        public string Password { get; set; }

        [Required]
        [RequireTrue]
        public bool WannaTrue { get; set; }

        [Required]
        [RequireFalse]
        public bool WannaFalse { get; set; }

        public static PropertyInfo GetProperty(string name)
            => typeof(RegisterViewModel).GetProperty(name);
    }
}