using MediatR;
using TechnicalTest.Domain.Common.Exceptions;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.Login
{
    public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserCommandResponse>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IAuthorization _authorization;
        private readonly IUnitOfWork _unitOfWork;

        public LoginUserCommandHandler(IGenericRepository genericRepository, IAuthorization authorization, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _authorization = authorization;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _genericRepository.Get<User>(user => user.Email == request.Email);
            if (user == null)
            {
                throw new AppDomainException("User not found");
            }

            var encryptPassword = _authorization.EncryptPassword(request.Password);
            if (!user.Login(request.Email, encryptPassword))
            {
                throw new AppDomainException("Invalid credentials");
            }
            var token = _authorization.GenerateToken(user);
            user.UpdateToken(token);
            _genericRepository.Update<User>(user);
            await _unitOfWork.Commit();

            var userResponse = new LoginUserCommandResponse(token);
            return userResponse;
        }
    }
}