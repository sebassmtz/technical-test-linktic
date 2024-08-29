using MediatR;

namespace TechnicalTest.Application.Users.Create
{
    public record CreateUserCommand(string Name, string Email, string Password) : IRequest<CreateUserCommandResponse>;
}