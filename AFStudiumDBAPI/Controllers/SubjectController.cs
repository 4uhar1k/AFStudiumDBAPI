using AFStudiumDBAPI.Data;
using Microsoft.AspNetCore.Mvc;
using AFStudiumDBAPI.Domains.Entitites;
using Microsoft.EntityFrameworkCore;

namespace AFStudiumDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubjectController: ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public SubjectController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Subject>> GetSubjects()
        {
            return _appDbContext.Subjectstable;
        }
        [HttpGet("{SubjectId}")]
        public async Task<Subject?> GetSubjectById(int SubjectId)
        {
            return await _appDbContext.Subjectstable.Where(n => n.SubjectId == SubjectId).SingleOrDefaultAsync();
        }
        [HttpPost]
        public async Task<ActionResult> PostSubject(Subject subject)
        {
            await _appDbContext.AddAsync(subject);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSubjects), new {SubjectId  = subject.SubjectId}, subject);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateSubject(Subject subject)
        {
            _appDbContext.Subjectstable.Update(subject);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{SubjectId}")]
        public async Task<ActionResult> DeleteSubject(int SubjectId)
        {
            var SubjectToDelete = await GetSubjectById(SubjectId);
            if (SubjectToDelete is null)
            {
                return NotFound();
            }
            else
            {                
                _appDbContext.Subjectstable.Remove(SubjectToDelete);
                await _appDbContext.SaveChangesAsync();
                return Ok();
            }
            
        }
    }
}
