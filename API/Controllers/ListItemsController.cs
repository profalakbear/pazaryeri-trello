using API.Data.Models;
using API.DTOs;
using API.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListItemsController : ControllerBase
    {
        private readonly IListItemsService _listItemsService;

        public ListItemsController(IListItemsService listItemsService)
        {
            _listItemsService = listItemsService;
        }

        // GET: api/<ListItemController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListItem>>> Get()
        {
            var listItems = await _listItemsService.GetAllListItemsAsync();
            return Ok(listItems);
        }

        // GET: api/ListItems/ByUser/5
        [HttpGet("ByUser/{userId}")]
        public async Task<ActionResult<IEnumerable<ListItem>>> GetByUser(int userId)
        {
            var listItems = await _listItemsService.GetListItemsByUserAsync(userId);

            return Ok(listItems);
        }

        // GET api/<ListItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListItem>> Get(int id)
        {
            var listItem = await _listItemsService.GetListItemAsync(id);
            if (listItem == null)
            {
                return NotFound();
            }
            return Ok(listItem);
        }

        // POST api/<ListItemController>
        [HttpPost]
        public async Task<ActionResult<ListItem>> Post([FromBody] ListDTO value)
        {
            value.CreatedAt = DateTime.UtcNow;
            value.UpdatedAt = DateTime.UtcNow;
            var newListItem = await _listItemsService.AddListItemAsync(value);
            return CreatedAtAction(nameof(Get), new { id = newListItem.ID }, newListItem);
        }

        // DELETE api/<ListItemController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _listItemsService.DeleteListItemAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
