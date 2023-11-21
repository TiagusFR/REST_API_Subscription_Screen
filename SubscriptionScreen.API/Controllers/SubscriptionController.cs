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
        // E possivel melhorar ainda mais seu codigo utilizando injeção de dependencia para esse servico que criei deixei como tarefa para vc visto que vc ja estava usando IoC
        private readonly SubscriptionService _service;
        private readonly SubscriptionDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubscriptionController(SubscriptionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _service = new SubscriptionService(_dbContext);
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
        public IActionResult Post(SubscriptionRequestDTO subscription)
        {
            _service.Add(_mapper.Map<Subscription>(subscription));

            return CreatedAtAction(nameof(GetById), new { id = subscription.Id }, subscription);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Subscription input)
        {
            _service.Update(id, input);

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
