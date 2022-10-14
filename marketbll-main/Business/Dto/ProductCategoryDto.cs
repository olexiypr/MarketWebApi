using System.Collections.Generic;

namespace Business.Dto;

public class ProductCategoryDto : BaseModel
{
    public string CategoryName { get; set; }
    private ICollection<int> ProductsId { get; set; }
}