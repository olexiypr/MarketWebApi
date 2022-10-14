using AutoMapper;
using Business.Common.Mapping;
using Business.Dto;
using Data.Entities;

namespace WebApi.Models;

public class AddProductDto : IMapWith<ProductDto>
{
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public ProductCategory ProductCategory { get; set; }
    public int? ProductCategoryId { get; set; }
    /*public void Mapping(Profile profile)
    {
        profile.CreateMap<AddProductDto, ProductDto>()
            .ForMember(command => command.Price,
                opt => opt.MapFrom(dto => dto.Price))
            .ForMember(command => command.ProductName,
                opt => opt.MapFrom(dto => dto.ProductName))
            .ForMember(command => command.ProductCategory,
                opt => opt.MapFrom(dto => dto.ProductCategory));
    }*/
}