using API.Data.Models;
using API.DTOs;
using API.ServiceContracts;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardsService _cardsService;

        public CardsController(ICardsService cardsService)
        {
            _cardsService = cardsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> Get()
        {
            var cards = await _cardsService.GetAllCardsAsync();
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> Get(int id)
        {
            var card = await _cardsService.GetCardAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        [HttpPost]
        public async Task<ActionResult<Card>> Post([FromBody] CardDTO value)
        {
            value.CreatedAt = DateTime.UtcNow;
            value.UpdatedAt = DateTime.UtcNow;
            var newCard = await _cardsService.AddCardAsync(value);
            return CreatedAtAction(nameof(Get), new { id = newCard.ID }, newCard);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Card value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            var updatedCard = await _cardsService.UpdateCardAsync(value);

            if (updatedCard == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cardsService.DeleteCardAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
