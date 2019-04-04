using System;

namespace SnowboardShop.Data.Models {
    public class Snowboard : Product {

        public Profile Profile { get; set; }

        public int Flex { get; set; }

    }
}
