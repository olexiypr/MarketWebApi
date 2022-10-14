using System;
using AutoMapper;
using Business.Commands.AddCommands.AddProduct;
using Business.Commands.Queries.GetAllProducts;
using Business.Commands.UpdateProduct;
using Business.ViewModels;
using Data.Entities;
using WebApi.Models;

namespace WebApi.Mapping;

public class AssemblyMappingProfile : Profile
{
    public AssemblyMappingProfile() =>
        ApplyMappingsFromAssembly();

    private void ApplyMappingsFromAssembly()
    {
        CreateMap<AddProductDto, AddProductCommand>()
            .ForMember(command => command.Price,
                opt => opt.MapFrom(dto => dto.Price))
            .ForMember(command => command.ProductName,
                opt => opt.MapFrom(dto => dto.ProductName))
            .ForMember(command => command.ProductCategoryId,
                opt => opt.MapFrom(dto => dto.ProductCategoryId ?? dto.ProductCategory.Id))
            .ForMember(command => command.ProductCategory,
                opt => opt.MapFrom(dto => dto.ProductCategory));

        CreateMap<UpdateProductDto, UpdateProductCommand>()
            .ForMember(command => command.Id,
                opt => opt.MapFrom(dto => dto.Id))
            .ForMember(command => command.Price,
                opt => opt.MapFrom(dto => dto.Price))
            .ForMember(command => command.ProductCategory,
                opt => opt.MapFrom(dto => dto.ProductCategory))
            .ForMember(command => command.ProductName,
                opt => opt.MapFrom(dto => dto.ProductName))
            .ForMember(command => command.ProductCategoryId,
                opt => opt.MapFrom(dto => dto.ProductCategoryId ?? dto.ProductCategory.Id));

        CreateMap<FilterModel, GetAllProductsQuery>()
            .ForMember(query => query.Predicate,
                opt => opt.MapFrom(model =>
                    model.CategoryId == null ? null : 
                    new Func<Product, bool>(product =>
                        product.Price < model.MaxPrice && product.Price > model.MinPrice && product.ProductCategoryId == model.CategoryId)));
    }
}