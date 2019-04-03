using System;

namespace SnowboardShop.Models {
    public class Error {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
      
    }
}