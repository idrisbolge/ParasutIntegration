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
            return "zaz2bBUPIuIiYK4w_fUCL_k9Mm3KYgs7PES5J44h7X8";
        }
    }
}
