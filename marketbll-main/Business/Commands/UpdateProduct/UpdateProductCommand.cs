using System.Collections.Generic;
using Business.ViewModels;
using Data.Entities;
using MediatR;

namespace Business.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<ProductVm>
{
    public int Id { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int? ProductCategoryId { get; set; }
    public ICollection<int> ReceiptDetailsId { get; set; }
}