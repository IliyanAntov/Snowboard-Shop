using SnowboardShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Services.Contracts {
    public interface ISnowboardsService {

        int CreateSnowboard(string name, string imagePath, decimal price, float size, string description, int brandId, Profile Profile, byte Flex);

    }
}
