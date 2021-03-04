using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Wangkanai.Validation.Models
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
        [RequireUniqueChar(2)]
        public string Password { get; set; }

        [Required]
        [RequireTrue]
        public bool WannaTrue { get; set; }

        [Required]
        [RequireFalse]
        public bool WannaFalse { get; set; }

        [RequireUniqueChar(1)]
        public string Unique1 { get; set; }

        [RequireUniqueChar(2)]
        public string Unique2 { get; set; }

        [RequireUniqueChar(3)]
        public string Unique3 { get; set; }
        
        [RequireUniqueChar(4)]
        public string Unique4 { get; set; }

        #region private

        public static PropertyInfo GetProperty(string name)
            => typeof(RegisterViewModel).GetProperty(name);

        #endregion
    }
}