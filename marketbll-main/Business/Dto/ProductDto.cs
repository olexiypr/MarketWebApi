using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Common.Mapping;
using Business.ViewModels;
using Data.Entities;

namespace Business.Dto;

public class ProductDto : BaseModel
{
    public ProductCategory ProductCategory { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public int? ProductCategoryId { get; set; }
    private ICollection<int> ReceiptDetailsId { get; set; }
}