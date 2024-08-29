using MediatR;
using TechnicalTest.Domain.Common.Ports;
using TechnicalTest.Domain.Users.Entities;
using TechnicalTest.Domain.Users.Exceptions;

namespace TechnicalTest.Application.Users.Delete
{
    public sealed class DeleteuserCommandHandler : IRequestHandler<DeleteuserCommand, DeleteuserCommandResponse>
    {
        private readonly IGenericRepository _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteuserCommandHandler(IGenericRepository genericRepository, IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteuserCommandResponse> Handle(DeleteuserCommand request, CancellationToken cancellationToken)
        {
            var user = await _genericRepository.Get<User>(user => user.Id == request.Id);
            if (user == null)
            {
                throw new UserDomainException("User not found");
            }
            _genericRepository.Delete<User>(user);
            await _unitOfWork.Commit();
            var userResponse = new DeleteuserCommandResponse(Unit.Value);
            return userResponse;
        }
    }
}