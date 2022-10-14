using MediatR;

namespace Business.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}