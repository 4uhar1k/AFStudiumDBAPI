using AFStudiumDBAPI.Data;
using AFStudiumDBAPI.Domains.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AFStudiumDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController: ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public EventController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            return _appDbContext.Eventstable;
        }
        [HttpGet("by-id/{EventId}")]
        public async Task<Event?> GetEventById(int EventId)
        {
            return await _appDbContext.Eventstable.Where(n => n.EventId == EventId).SingleOrDefaultAsync();
        }
        [HttpGet("by-subjectid/{SubjectId}")]
        public ActionResult<IEnumerable<Event>> GetEventsBySubjectId(int SubjectId)
        {
            List<Event> e = _appDbContext.Eventstable.Where(n => n.SubjectId == SubjectId).ToList();
            return (ActionResult<IEnumerable<Event>>)e;
        }
        [HttpGet("by-createdperson/{CreatedPerson}")]
        public ActionResult<IEnumerable<Event>> GetMyEvents(int CreatedPerson)
        {
            List<Event> e = _appDbContext.Eventstable.Where(n => n.CreatedPerson == CreatedPerson).ToList();
            return (ActionResult<IEnumerable<Event>>)e;
        }
        [HttpPost]
        public async Task<ActionResult> PostEvent(Event e)
        {
            await _appDbContext.AddAsync(e);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvents), new { EventId = e.EventId }, e);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateEvent(Event e)
        {
            _appDbContext.Eventstable.Update(e);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{EventId}")]
        public async Task<ActionResult> DeleteEvent(int EventId)
        {
            var EventToDelete = await GetEventById(EventId);
            if (EventToDelete is null)
            {
                return NotFound();
            }
            else
            {
                _appDbContext.Eventstable.Remove(EventToDelete);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }

        }
    }
}
