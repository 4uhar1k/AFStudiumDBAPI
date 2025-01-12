using AFStudiumDBAPI.Data;
using AFStudiumDBAPI.Domains.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AFStudiumDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController: ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public MessageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Message>> GetMessages()
        {
            return _appDbContext.Messagestable;
        }
        [HttpGet("byid/{MessageId}")]
        public async Task<Message?> GetMessageById(int MessageId)
        {
            return await _appDbContext.Messagestable.Where(n => n.MessageId == MessageId).SingleOrDefaultAsync();
        }
        [HttpGet("byauthor/{SendFrom}")]
        public ActionResult<IEnumerable<Message>> GetMessagesByAuthor(int SendFrom)
        {
            List<Message> e = _appDbContext.Messagestable.Where(n => n.SendFrom == SendFrom).ToList();
            return (ActionResult<IEnumerable<Message>>)e;
        }
        [HttpGet("byreceiver/{SendTo}")]
        public ActionResult<IEnumerable<Message>> GetMessagesByReceiver(int SendTo)
        {
            List<Message> e = _appDbContext.Messagestable.Where(n => n.SendTo == SendTo).ToList();
            return (ActionResult<IEnumerable<Message>>)e;
        }
        [HttpPost]
        public async Task<ActionResult> PostMessage(Message m)
        {
            await _appDbContext.AddAsync(m);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMessages), new { EventId = m.MessageId }, m);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateMessage(Message m)
        {
            _appDbContext.Messagestable.Update(m);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{MessageId}")]
        public async Task<ActionResult> DeleteMessage(int MessageId)
        {
            var MessageToDelete = await GetMessageById(MessageId);
            if (MessageToDelete is null)
            {
                return NotFound();
            }
            else
            {
                _appDbContext.Messagestable.Remove(MessageToDelete);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }

        }
    }
}
