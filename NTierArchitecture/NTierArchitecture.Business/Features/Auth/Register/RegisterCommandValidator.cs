using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace NTierArchitecture.Business.Features.Auth;

public sealed class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(p => p.UserName).NotEmpty().WithMessage("Username cannot be empty!");
        RuleFor(p => p.UserName).NotNull().WithMessage("Username cannot be empty!");
        RuleFor(p => p.UserName).MinimumLength(3).WithMessage("Username must be at least 3 characters.");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Namespace cannot be empty.");
        RuleFor(p => p.Name).NotNull().WithMessage("Namespace cannot be empty.");
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("The name field must be at least 3 characters.");
        RuleFor(p => p.LastName).NotEmpty().WithMessage("Last Name cannot be empty.");
        RuleFor(p => p.LastName).NotNull().WithMessage("Last Name cannot be empty.");
        RuleFor(p => p.LastName).MinimumLength(3).WithMessage("The Last Name field must be at least 3 characters.");
        RuleFor(p => p.Email).NotEmpty().WithMessage("EMail cannot be empty.");
        RuleFor(p => p.Email).NotNull().WithMessage("EMail cannot be empty.");
        RuleFor(p => p.Email).MinimumLength(3).WithMessage("Email field must be at least 3 characters.");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Password cannot be empty.");
        RuleFor(p => p.Password).NotNull().WithMessage("Password cannot be empty.");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Password field must be at least 3 characters.");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Password must contain at least 1 uppercase letter.");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Password must contain at least 1 lowercase.");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Password must be contain at least 1 figure.");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password must be contain at least 1 special character.");
    }
}
