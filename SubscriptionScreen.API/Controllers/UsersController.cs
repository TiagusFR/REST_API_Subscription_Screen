using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubscriptionScreen.API.Controllers.Request;
using SubscriptionScreen.API.Entities;
using SubscriptionScreen.API.Persistence;
using SubscriptionScreen.API.Services;

namespace SubscriptionScreen.API.Controllers

{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _service.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(UserRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<User>(request));

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateUserRequestDTO request)
        {
            _service.Update(id, request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);

            return NoContent();
        }
    }
}
