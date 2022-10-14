using AutoMapper;
using Business.Common.Mapping;
using Business.Dto;
using Data.Entities;

namespace Business.ViewModels;

public class ProductVm : IMapWith<Product>
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string ProductCategoryName { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductVm>();
    }
}