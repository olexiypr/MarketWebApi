using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Commands.Exceptions;
using Business.ViewModels;
using Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Commands.Queries.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductVm>
{
    private readonly IProductDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetProductByIdQueryHandler(IProductDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<ProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product =
            await _dbContext.Products.Include(product => product.Category)
                .FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException(nameof(product), request.Id);
        }

        return _mapper.Map<ProductVm>(product);
    }
}