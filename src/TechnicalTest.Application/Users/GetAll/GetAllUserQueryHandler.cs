using MediatR;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.GetAll
{
    internal sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, GetAllUserQueryResponse>
    {

        private readonly IGenericRepository _genericRepository;

        public GetAllUserQueryHandler(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _genericRepository.GetAll<User>();
            var userDTOs = users.Select(user => new UserDTO(user.Id, user.Name, user.Email));
            var userResponse = new GetAllUserQueryResponse(userDTOs);
            return userResponse;
        }
    }
}
