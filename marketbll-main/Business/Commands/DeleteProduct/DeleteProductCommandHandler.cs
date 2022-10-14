using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Commands.Exceptions;
using Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Business.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IMapper _mapper;
    private readonly IProductDbContext _dbContext;

    public DeleteProductCommandHandler(IProductDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = 
            await _dbContext.Products.FirstOrDefaultAsync(product => product.Id == request.Id, cancellationToken);
        if (product == null)
        {
            throw new NotFoundException(nameof(product), request.Id);
        }
        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}