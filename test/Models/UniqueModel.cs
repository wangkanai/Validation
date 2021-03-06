﻿using System.ComponentModel.DataAnnotations;

namespace Wangkanai.Validation.Models
{
    public class UniqueModel : BaseModel<UniqueModel>
    {
        [RequireUniqueChar(1)]
        public string Unique1 { get; set; }

        [RequireUniqueChar(2)]
        public string Unique2 { get; set; }

        [RequireUniqueChar(3)]
        public string Unique3 { get; set; }

        [RequireUniqueChar(4)]
        public string Unique4 { get; set; }
    }
}