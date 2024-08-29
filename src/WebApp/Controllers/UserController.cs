using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalTest.Application.Users.Create;
using TechnicalTest.Application.Users.Delete;
using TechnicalTest.Application.Users.Get;
using TechnicalTest.Application.Users.GetAll;
using TechnicalTest.Application.Users.Login;
using TechnicalTest.Application.Users.Update;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Get()
        {
            var listQuery = new GetAllUserQuery();
            var response = await _mediator.Send(listQuery);
            return Ok(response);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var queryResponse = new GetUserQuery(id);
            var response = await _mediator.Send(queryResponse);
            return Ok(response);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserCommand)
        {
            var createUserCommandResponse = await _mediator.Send(createUserCommand);
            return CreatedAtAction(nameof(Post), createUserCommandResponse);
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginCommand)
        {
            var dtoLogin = await _mediator.Send(loginCommand);
            return Ok(dtoLogin);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserCommand updateUserCommand)
        {
            var updateCommand = new UpdateUserCommand(id, updateUserCommand.Name, updateUserCommand.Email, updateUserCommand.Password);
            await _mediator.Send(updateCommand);
            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteUserCommandResponse = new DeleteuserCommand(id);
            var response = await _mediator.Send(deleteUserCommandResponse);
            return NoContent();
        }
    }
}
