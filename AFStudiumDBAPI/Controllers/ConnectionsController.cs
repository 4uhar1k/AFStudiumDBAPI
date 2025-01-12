using AFStudiumDBAPI.Data;
using AFStudiumDBAPI.Domain.Entities;
using AFStudiumDBAPI.Domains.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AFStudiumDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionsController: ControllerBase
    {
        private AppDbContext _appDbContext;
        public ConnectionsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Connections>> GetConnections()
        {
            return _appDbContext.ConnectionsTable;
        }
        [HttpGet("bystudentid/{StudentId}")]
        public async Task<List<Connections>?> GetConnectionsByStudentId(int StudentId)
        {
            return await _appDbContext.ConnectionsTable.Where(n=> n.StudentId == StudentId).ToListAsync();
        }
        [HttpGet("byeventid/{EventId}")]
        public async Task<List<Connections>?> GetConnectionsByEventId(int EventId)
        {
            return await _appDbContext.ConnectionsTable.Where(n => n.EventId == EventId).ToListAsync();
        }
        [HttpGet("{StudentId},{EventId}")]
        public async Task<ActionResult<Connections?>> GetUniqueConnection(int StudentId, int EventId)
        {
            return await _appDbContext.ConnectionsTable.Where(n=>n.StudentId == StudentId & n.EventId==EventId).SingleOrDefaultAsync();
        }
        [HttpPost]
        public async Task<ActionResult> AddConnection(Connections studentsEvents)
        {
            // = new StudentsEvents() { StudentId = user.MatrikelNum, EventId = e.EventId };
            await _appDbContext.AddAsync(studentsEvents);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetConnections), new { Id = studentsEvents.Id }, studentsEvents);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateConnection(Connections studentsEvents)
        {
            _appDbContext.ConnectionsTable.Update(studentsEvents);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteConnection(int Id)
        {
            Connections? ConnectionToDelete = await _appDbContext.ConnectionsTable.Where(n => n.Id == Id).FirstOrDefaultAsync();
            if (ConnectionToDelete != null)
            {
                _appDbContext.ConnectionsTable.Remove(ConnectionToDelete);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
