using System.Security.Claims;
using Business.Dto;
using Business.ViewModels;
using MediatR;

namespace Business.Auth;

public class IdentityCommand : IRequest<string>
{
    public string Login { get; set; }
    public string Password { get; set; }
}