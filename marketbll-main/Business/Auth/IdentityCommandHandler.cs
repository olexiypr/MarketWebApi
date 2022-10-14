using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.ViewModels;
using Data.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Business.Auth;

public class IdentityCommandHandler : IRequestHandler<IdentityCommand, string>
{
    private readonly ICustomerDbContext _dbContext;
    private readonly IMapper _mapper;

    public IdentityCommandHandler(ICustomerDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<string> Handle(IdentityCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dbContext.Customers.FirstOrDefaultAsync(customer =>
            customer.Login == request.Login && customer.Password == request.Password, cancellationToken);
        if (customer == null)
            throw new UserAccessDeniedExceptions($"Login: {request.Login}, password: {request.Password}");
        var claims = new List<Claim>
        {
            new (ClaimsIdentity.DefaultNameClaimType, customer.Login),
            new (ClaimsIdentity.DefaultRoleClaimType, customer.Role)
        };
        var now = DateTime.Now;
        var jwt = new JwtSecurityToken(
            issuer:AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            notBefore: now,
            claims: claims,
            expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;

    }
}