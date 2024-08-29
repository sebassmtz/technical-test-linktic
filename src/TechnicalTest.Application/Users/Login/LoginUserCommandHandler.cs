using MediatR;
using TechnicalTest.Domain.Common.Ports;

namespace TechnicalTest.Application.Users.Login
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IAuthorization _authorization;

        public LoginUserCommandHandler(IGenericRepository genericRepository, IAuthorization authorization)
        {
            _genericRepository = genericRepository;
            _authorization = authorization;
        }

        public Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // Implement your logic here
            throw new NotImplementedException();
        }
    }
}