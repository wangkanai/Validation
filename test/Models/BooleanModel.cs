using System.ComponentModel.DataAnnotations;

namespace Wangkanai.Validation.Models
{
    public class BooleanModel : BaseModel
    {
        [Required]
        [RequireTrue]
        public bool WannaTrue { get; set; }

        [Required]
        [RequireFalse]
        public bool WannaFalse { get; set; }
    }
}