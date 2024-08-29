using MediatR;

namespace TechnicalTest.Application.Users.Delete
{
    public record DeleteuserCommand(Guid Id) : IRequest<DeleteuserCommandResponse>;
}