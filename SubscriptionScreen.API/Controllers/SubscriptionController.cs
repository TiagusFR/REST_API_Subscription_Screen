using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubscriptionScreen.API.Entities;
using SubscriptionScreen.API.Persistence;

namespace SubscriptionScreen.API.Controllers
{
    [Route("api/subscriptions")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionDbContext _context;

        public SubscriptionController(SubscriptionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var subscription = _context.Subscriptions.Where(x => !x.IsDeleted).ToList();

            return Ok(subscription);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var subscription = _context.Subscriptions.Where(x => x.Id == id);

            if (subscription == null) 
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        [HttpPost]
        public IActionResult Post(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);

            return CreatedAtAction(nameof(GetById), new {id = subscription.Id}, subscription);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Subscription input)
        {
            var subscription = _context.Subscriptions.SingleOrDefault(x => x.Id == id);

            if (subscription == null)
            {
                return NotFound();
            }

            subscription.Update(input.Name, input.SubscriptionType, input.CreationDate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var subscription = _context.Subscriptions.SingleOrDefault(x => x.Id == id);

            if (subscription == null)
            {
                return NotFound();
            }

            subscription.Delete();

            return NoContent();
        }
    }
}
