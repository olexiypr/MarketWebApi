using Data.Entities;

namespace WebApi.Models;

public class UpdateProductDto
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public int? ProductCategoryId { get; set; }
}