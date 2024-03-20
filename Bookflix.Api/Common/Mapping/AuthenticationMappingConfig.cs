using Bookflix.Application.Authentication;
using Bookflix.Application.Authentication.Commands.Register;
using Bookflix.Application.Authentication.Queries.Login;
using Bookflix.Contracts.Authentication;
using Mapster;

namespace Bookflix.Api.Common;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginQuery, LoginRequest>();

        config.NewConfig<RegisterCommand, RegisterRequest>();
        
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}