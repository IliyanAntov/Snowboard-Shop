using System;
using System.ComponentModel.DataAnnotations;

namespace SnowboardShop.Data.Models {
    public class Snowboard : Product {

        public Profile Profile { get; set; }
        
        [Range(1, 10, ErrorMessage = "{0} value must be between {1} and {2}")]
        public byte Flex { get; set; }

    }
}
