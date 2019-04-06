using System;
using System.ComponentModel.DataAnnotations;

namespace SnowboardShop.Data.Models {
    public class Snowboard : Product {

        public Profile Profile { get; set; }

        [Required]
        public byte Flex { get; set; }

    }
}
