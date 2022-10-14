using System.Collections.Generic;

namespace Business.ViewModels;

public class ProductCategoryVm
{
    public string CategoryName { get; set; }
    public IEnumerable<ProductVm> Products { get; set; }
}