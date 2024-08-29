using MediatR;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;
using TechnicalTest.Domain.Users.Exceptions;

namespace TechnicalTest.Application.Users.Get
{
    internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
    {

        private readonly IGenericRepository _genericRepository;

        public GetUserQueryHandler(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {

            var user = await _genericRepository.Get<User>(user => user.Id == request.Id);
            if (user == null) {
                throw new UserDomainException("User not found");
            }

            var userResponse = new GetUserQueryResponse(user.Id, user.Name, user.Email);
            return userResponse;
        }
    }
}
