using Business.Dto;
using Business.ViewModels;
using MediatR;

namespace Business.Commands.AddCommands.AddProductCategory;

public class AddProductCategoryCommand : IRequest<ProductCategoryVm>
{
    public ProductCategoryDto ProductCategoryDto { get; set; }
}