using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Services.Contracts {
    public interface ISnowboardsService {

        int CreateSnowboard(string name, decimal price, float size, string description, int brandId, char Profile, int Flex);

    }
}
