using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Features.Auth.Login;

public sealed class LoginCommandValidator :AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(p => p.UserNameOrEmail).NotEmpty().WithMessage("Username or Email cannot be empty!");
        RuleFor(p => p.UserNameOrEmail).NotNull().WithMessage("Username or Email cannot be empty!");
        RuleFor(p => p.UserNameOrEmail).MinimumLength(3).WithMessage("Username or email must be at least 3 characters.");
        RuleFor(p => p.Password).NotEmpty().WithMessage("Password cannot be empty.");
        RuleFor(p => p.Password).NotNull().WithMessage("Password cannot be empty.");
        RuleFor(p => p.Password).MinimumLength(6).WithMessage("Password field must be at least 3 characters.");
        RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Password must contain at least 1 uppercase letter.");
        RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Password must contain at least 1 lowercase.");
        RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Password must be contain at least 1 figure.");
        RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password must be contain at least 1 special character.");

    }
}
