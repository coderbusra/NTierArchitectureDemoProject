using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArchitecture.Business.Features.Auth;
using NTierArchitecture.Business.Features.Auth.Login;
using NTierArchitecture.WebApi.Abstractions;

namespace NTierArchitecture.WebApi.Controllers;

public sealed class AuthController : ApiController 
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var respon = await _mediator.Send(request, cancellationToken);
        return NoContent();
    }
}
