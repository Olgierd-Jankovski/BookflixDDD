using Bookflix.Application.Authors.Commands;
using Bookflix.Application.Authors.Common;
using Bookflix.Contracts.Authors;
using Mapster;

namespace Bookflix.Api.Common.Mapping;

public class AuthorsMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(BecomeAuthorRequest Request, int UserId), CreateAuthorCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<AuthorResult, AuthorResponse>()
            .Map(dest => dest, src => src);
    }
}