using MediatR;

namespace NTierArchitecture.Business.Features.Auth;

public sealed record RegisterCommand(
    string Name,
    string LastName,
    string Email,
    string UserName,
    string Password) : IRequest<Unit>;
