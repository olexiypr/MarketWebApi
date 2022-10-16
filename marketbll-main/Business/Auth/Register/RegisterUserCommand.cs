using System;
using MediatR;

namespace Business.Auth.Register;

public class RegisterUserCommand : IRequest<string>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}