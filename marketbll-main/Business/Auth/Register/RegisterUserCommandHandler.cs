using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using MediatR;

namespace Business.Auth.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
{
    private readonly ICustomerDbContext _dbContext;
    private readonly IMapper _mapper;
    public RegisterUserCommandHandler(ICustomerDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
    public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Customer>(request);
        await _dbContext.Customers.AddAsync(customer, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var token = await new IdentityCommandHandler(_dbContext, _mapper).Handle(
            new IdentityCommand
            {
                Password = request.Password,
                Login = request.Login
            }, cancellationToken);
        return token;
    }
}