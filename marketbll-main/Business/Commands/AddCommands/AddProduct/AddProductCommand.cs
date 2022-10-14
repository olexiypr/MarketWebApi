using System.Collections.Generic;
using Business.Dto;
using Business.ViewModels;
using Data.Entities;
using MediatR;

namespace Business.Commands.AddCommands.AddProduct;

public class AddProductCommand : IRequest<ProductVm>
{
    public ProductCategory ProductCategory { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int? ProductCategoryId { get; set; }
    private ICollection<int> ReceiptDetailsId { get; set; }
}