using System.ComponentModel.DataAnnotations;

namespace Wangkanai.Validation.Models
{
    public class UppercaseModel : BaseModel
    {
        [RequireUppercase]
        public string Password { get; set; }
    }
}