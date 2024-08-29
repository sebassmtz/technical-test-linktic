using MediatR;

namespace TechnicalTest.Application.Users.Get
{
    public record GetUserQuery(Guid Id) : IRequest<GetUserQueryResponse>;
}
