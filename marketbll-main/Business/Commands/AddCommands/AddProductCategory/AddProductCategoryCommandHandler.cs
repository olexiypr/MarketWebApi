using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.ViewModels;
using Data.Entities;
using Data.Interfaces;
using MediatR;

namespace Business.Commands.AddCommands.AddProductCategory;

public class AddProductCategoryCommandHandler : IRequestHandler<AddProductCategoryCommand, ProductCategoryVm>
{
    private readonly IProductCategoryDbContext _dbContext;
    private readonly IMapper _mapper;
    public AddProductCategoryCommandHandler(IProductCategoryDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<ProductCategoryVm> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<ProductCategory>(request.ProductCategoryDto);
        await _dbContext.ProductCategories.AddAsync(category, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ProductCategoryVm>(category);
    }
}