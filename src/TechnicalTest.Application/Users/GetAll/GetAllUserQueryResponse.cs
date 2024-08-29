using TechnicalTest.Domain.Users.Entities;

namespace TechnicalTest.Application.Users.GetAll
{
    public record GetAllUserQueryResponse(IEnumerable<UserDTO> Users);
}
