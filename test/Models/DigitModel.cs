using System.ComponentModel.DataAnnotations;

namespace Wangkanai.Validation.Models
{
    public class DigitModel : BaseModel
    {
        [RequireDigit]
        public string Password { get; set; }
    }
}