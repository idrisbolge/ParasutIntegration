using MediatR;

namespace ParasutIntegration.Features.Auth.Queries
{
    public class GetTokenQueries : IRequest<string>
    {
    }

    public class GetTokenQueriesHandler : IRequestHandler<GetTokenQueries, string>
    {
        public async Task<string> Handle(GetTokenQueries request, CancellationToken cancellationToken)
        {
            return "CMCqVxohU8I4Fl2eZNOgU5MbQF2LW5ULxrZ3QVhOL8g";
        }
    }
}
