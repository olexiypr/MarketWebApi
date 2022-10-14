using Business.ViewModels;
using MediatR;

namespace Business.Commands.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<ProductVm>
{
    public int Id { get; set; }
}