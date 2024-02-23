using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubscriptionScreen.API.Controllers.Request;
using SubscriptionScreen.API.Entities;
using SubscriptionScreen.API.Persistence;
using SubscriptionScreen.API.Services;

namespace SubscriptionScreen.API.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;
        private readonly IMapper _mapper;

        public SubscriptionController(ISubscriptionService service, IMapper mapper)
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
            var subscription = _service.GetById(id);

            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        [HttpPost]
        public IActionResult Post(SubscriptionRequestDTO request)
        {
            var result = _service.Add(_mapper.Map<Subscription>(request));

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id,UpdateSubscriptionRequestDTO request)
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
