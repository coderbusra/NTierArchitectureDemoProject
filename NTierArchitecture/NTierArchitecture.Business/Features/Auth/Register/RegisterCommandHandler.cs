using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArchicture.Entites.Models;

namespace NTierArchitecture.Business.Features.Auth;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var checkUserNameExists = await _userManager.FindByNameAsync(request.UserName);
        if (checkUserNameExists is not null)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış!");
        }

        var checkEmailNameExists = await _userManager.FindByEmailAsync(request.Email);

        if (checkEmailNameExists is not null)
        {
            throw new ArgumentException("Bu mail adresi dahha öncekullanılmış!");
        }

        AppUser appUser = new()
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name,
            Lastname = request.LastName,
            UserName = request.UserName
        };

        await _userManager.CreateAsync(appUser, request.Password);

        return Unit.Value;
    }
}