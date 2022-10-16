using System;
using Business.Commands.AddCommands.AddProduct;
using FluentValidation;

namespace Business.Auth.Register;

public class RegisterValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterValidator()
    {
        RuleFor(command => command.Login).NotEmpty().MaximumLength(30);
        RuleFor(command => command.Password).NotEmpty().MaximumLength(30);
        RuleFor(command => command.Name).NotEmpty().MaximumLength(30);
        RuleFor(command => command.Surname).NotEmpty().MaximumLength(30);
        RuleFor(command => command.BirthDate).NotEmpty().Must(time => time < DateOnly.Parse("01/01/2010"));
    }
}