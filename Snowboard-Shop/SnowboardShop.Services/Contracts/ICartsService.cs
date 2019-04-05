using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Services.Contracts {
    public interface ICartsService {

        int AddItem(int productId, string username);

        int RemoveItem(int id);
    }
}
