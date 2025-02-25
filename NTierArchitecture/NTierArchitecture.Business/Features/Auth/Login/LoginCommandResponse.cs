using MediatR;

namespace NTierArchitecture.Business.Features.Auth.Login;

public sealed record LoginCommandResponse(
    string AccessToken,
    Guid UserId): IRequest<string>;
