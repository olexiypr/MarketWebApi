using System.Collections.Generic;
using Business.Dto;

namespace Business.ViewModels
{
    public class ProductsVm
    {
        public IEnumerable<ProductVm> ProductModels { get; set; }
    }
}