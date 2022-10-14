using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Business.Commands.AddCommands.AddProduct;
using Business.Commands.UpdateProduct;
using Business.Dto;
using Business.ViewModels;
using Data.Entities;

namespace Business.Common.Mapping
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile() => 
            ApplyMappingsFromAssembly();
        private void ApplyMappingsFromAssembly()
        {
            CreateMap<Product, ProductVm>()
                .ForMember(vm => vm.Price,
                    opt => opt.MapFrom(product => product.Price))
                .ForMember(vm => vm.ProductCategoryName,
                    opt => opt.MapFrom(product => product.Category.CategoryName))
                .ForMember(vm => vm.ProductName,
                    opt => opt.MapFrom(product => product.ProductName));

            CreateMap<Product, AddProductCommand>()
                .ForMember(dto => dto.Price,
                    opt => opt.MapFrom(product => product.Price))
                .ForMember(dto => dto.ProductName,
                    opt => opt.MapFrom(product => product.ProductName))
                .ForMember(dto => dto.ProductCategory,
                    opt => opt.MapFrom(product => product.Category))
                .ForMember(dto => dto.ProductCategoryId,
                    opt => opt.MapFrom(product => product.ProductCategoryId))
                .ReverseMap();

            CreateMap<ProductCategoryDto, ProductCategory>()
                .ForMember(category => category.CategoryName,
                    opt => opt.MapFrom(dto => dto.CategoryName));
            
            CreateMap<ProductCategoryDto, ProductCategory>()
                .ForMember(category => category.CategoryName,
                    opt => opt.MapFrom(dto => dto.CategoryName));

            CreateMap<UpdateProductCommand, Product>()
                .ForMember(product => product.Price,
                    opt => opt.MapFrom(command => command.Price))
                .ForMember(product => product.ProductName,
                    opt => opt.MapFrom(command => command.ProductName))
                .ForMember(product => product.ReceiptDetails,
                    opt => opt.MapFrom(command => command.ReceiptDetailsId))
                .ForMember(product => product.Category,
                    opt => opt.MapFrom(command => command.ProductCategory))
                .ForMember(product => product.ProductCategoryId,
                    opt => opt.MapFrom(command => command.ProductCategoryId ?? command.ProductCategory.Id));
        }
    }
}