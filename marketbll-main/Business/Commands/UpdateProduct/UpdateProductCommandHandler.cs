using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Commands.Exceptions;
using Business.ViewModels;
using Data.Entities;
using Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductVm>
{
    private readonly IMapper _mapper;
    private readonly IProductDbContext _dbContext;

    public UpdateProductCommandHandler(IProductDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<ProductVm> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        var productFromDb = 
            await _dbContext.Products.FirstOrDefaultAsync(product1 => product1.Id == product.Id, cancellationToken);;
        if (productFromDb == null)
        {
            throw new NotFoundException(nameof(product), request.Id);
        }
        productFromDb = product;
        await _dbContext.Products.AddAsync(productFromDb, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProductVm>(productFromDb);
    }
}