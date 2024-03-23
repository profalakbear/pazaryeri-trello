using API.Data.Models;
using API.ServiceContracts;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService _logsService;

        public LogsController(ILogsService logsService)
        {
            _logsService = logsService;
        }

        // GET: api/<LogsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> Get()
        {
            var logs = await _logsService.GetAllLogsAsync();
            return Ok(logs);
        }

        // GET api/<LogsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> Get(int id)
        {
            var log = await _logsService.GetLogAsync(id);
            if (log == null)
            {
                return NotFound();
            }
            return Ok(log);
        }

        // POST api/<LogsController>
        [HttpPost]
        public async Task<ActionResult<Log>> Post([FromBody] Log value)
        {
            var newLog = await _logsService.AddLogAsync(value);
            return CreatedAtAction(nameof(Get), new { id = newLog.ID }, newLog);
        }

        // PUT api/<LogsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Log value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            var updatedLog = await _logsService.UpdateLogAsync(value);

            if (updatedLog == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<LogsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _logsService.DeleteLogAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
