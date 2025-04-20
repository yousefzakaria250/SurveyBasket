
using Microsoft.Extensions.FileProviders;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase // Primary Constructor Syntax
    {
        private readonly IPollService _pollService = pollService; 

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_pollService.GetAll());    
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            var poll = _pollService.Get(Id);
            return poll is null ? NotFound() : Ok(poll);   
        }

        [HttpPost("")]
        public IActionResult Add(Poll _poll)
        {
          var poll =  _pollService.Add(_poll);
            return CreatedAtAction(nameof(Get), new { Id = poll.Id } , poll); // Add New Resource
        }

       [HttpPut]
        public IActionResult Update(int Id , Poll _poll) 
        {
            var isUpdated = _pollService.Update(Id , _poll);  
            if(!isUpdated)
                return NotFound();
            return NoContent(); // no Content
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        { 
           var isDeleted = _pollService.Delete(Id); 
            if(! isDeleted) 
                return NotFound();
            return NoContent();
        
        }
    }
}
