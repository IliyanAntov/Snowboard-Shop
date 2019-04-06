using System;
using System.Collections.Generic;
using System.Text;
using SnowboardShop.ViewModels;

namespace SnowboardShop.Services.Contracts {
    public interface IBrandsService {

        int CreateBrand(string name);

        List<ListBrandsViewModel> GetAllBrandsViewModel();
    }
}
