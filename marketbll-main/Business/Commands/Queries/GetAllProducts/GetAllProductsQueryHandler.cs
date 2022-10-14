using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Commands.Exceptions;
using Business.Dto;
using Business.ViewModels;
using Data.Data;
using Data.Entities;
using Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Commands.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductsVm>
{
    private readonly IProductDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<ProductsVm> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        if (request.Predicate == null)
        {
            var products = await _dbContext.Products
                .Include(product => product.Category)
                .ProjectTo<ProductVm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            
            return new ProductsVm {ProductModels = products};
        }
        else
        {
            var products = await _dbContext.Products
                .Include(product => product.Category)
                .ToListAsync(cancellationToken);
            
            var filteredProducts = products.Where(request.Predicate);
            if (!filteredProducts.Any())
            {
                throw new NotFoundException(nameof(filteredProducts), request.Predicate);
            }

            var productsVms = filteredProducts.Select(product => _mapper.Map<ProductVm>(product));
            return new ProductsVm {ProductModels = productsVms};
        }
    }
}