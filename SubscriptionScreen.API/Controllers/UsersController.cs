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
        private readonly UserService _service;
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersController(UserDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _service = new UserService(dbContext);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _service.GetbyId(id);

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
