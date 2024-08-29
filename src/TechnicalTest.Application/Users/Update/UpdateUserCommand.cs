using MediatR;

namespace TechnicalTest.Application.Users.Update
{
    public record UpdateUserCommand(Guid Id, string Name, string Email, string Password) : IRequest<UpdateUserCommandResponse>;
}