using MediatR;

namespace TechnicalTest.Application.Users.Login
{
    public record LoginUserCommand(string Email, string Password) : IRequest<LoginUserCommandResponse>;
}