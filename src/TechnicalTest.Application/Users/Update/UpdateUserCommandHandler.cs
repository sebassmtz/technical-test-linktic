using MediatR;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;
using TechnicalTest.Domain.Users.Exceptions;

namespace TechnicalTest.Application.Users.Update
{
    public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IGenericRepository genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _genericRepository.Get<User>(user => user.Id == request.Id);
            if (user == null)
            {
                throw new UserDomainException("User not found");
            }
            _genericRepository.Update<User>(user);
            await _unitOfWork.Commit();
            var userResponse = new UpdateUserCommandResponse(Unit.Value);
            return userResponse;
        }
    }
}