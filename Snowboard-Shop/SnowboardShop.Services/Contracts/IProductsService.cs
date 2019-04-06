using SnowboardShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnowboardShop.Services.Contracts {
    public interface IProductsService {

        List<ListProductViewModel> GetAllProductsViewModel();

    }
}
