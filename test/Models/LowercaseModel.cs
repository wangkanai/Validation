using System.ComponentModel.DataAnnotations;

namespace Wangkanai.Validation.Models
{
    public class LowercaseModel : BaseModel
    {
        [RequireLowercase]
        public string Password { get; set; }
    }
}