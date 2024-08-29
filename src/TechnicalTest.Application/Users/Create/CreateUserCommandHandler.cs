using MediatR;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;
using TechnicalTest.Domain.Users.Exceptions;

namespace TechnicalTest.Application.Users.Create
{
    public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorization _authorization;

        public CreateUserCommandHandler(IGenericRepository genericRepository, IUnitOfWork unitOfWork, IAuthorization authorization)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _authorization = authorization;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _genericRepository.Get<User>(user => user.Email == request.Email);
            if (user != null)
            {
                throw new UserDomainException("User already exists");
            }

            var encryptPassword = _authorization.EncryptPassword(request.Password);
            var createuser = User.Create(request.Name, request.Email, encryptPassword);
            _genericRepository.Save<User>(createuser);
            await _unitOfWork.Commit();
            var userResponse = new CreateUserCommandResponse(createuser.Id, createuser.Name, createuser.Email);
            return userResponse;
        }
    }
}