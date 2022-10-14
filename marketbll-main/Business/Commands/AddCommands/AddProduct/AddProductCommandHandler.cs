using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.ViewModels;
using Data.Entities;
using Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Commands.AddCommands.AddProduct;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductVm>
{
    private readonly IProductDbContext _productDbContext;
    private readonly IProductCategoryDbContext _productCategoryDbContext;
    private readonly IMapper _mapper;

    public AddProductCommandHandler(IProductDbContext dbContext, IProductCategoryDbContext productCategoryDbContext, IMapper mapper)
        => (_productDbContext, _productCategoryDbContext, _mapper) = (dbContext, productCategoryDbContext, mapper);
    public async Task<ProductVm> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        product.Category ??= await _productCategoryDbContext.ProductCategories.FirstAsync(category =>
            category.Id == product.ProductCategoryId, cancellationToken);
        await _productDbContext.Products.AddAsync(product, cancellationToken);
        await _productDbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProductVm>(product);
    }
}