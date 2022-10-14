using System;
using FluentValidation;

namespace Business.Commands.AddCommands.AddProduct;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(command => command.Price)
            .Must(price => price > 0);
        RuleFor(command => command.ProductName)
            .NotEmpty()
            .MaximumLength(100);
    }
}