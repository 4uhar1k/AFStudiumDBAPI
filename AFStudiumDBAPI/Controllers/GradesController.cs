using AFStudiumDBAPI.Data;
using AFStudiumDBAPI.Domains.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AFStudiumDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController: ControllerBase
    {
        private AppDbContext _appDbContext;
        public GradesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Grades>> GetGrades()
        {
            return _appDbContext.GradesTable;
        }
        [HttpGet("bystudentid/{StudentId}")]
        public async Task<List<Grades>?> GetGradesByStudentId(int StudentId)
        {
            return await _appDbContext.GradesTable.Where(n => n.StudentId == StudentId).ToListAsync();
        }
        [HttpGet("byeventid/{EventId}")]
        public async Task<List<Grades>?> GetGradesByEventId(int EventId)
        {
            return await _appDbContext.GradesTable.Where(n => n.EventId == EventId).ToListAsync();
        }
        [HttpGet("{StudentId},{EventId}")]
        public async Task<ActionResult<Grades?>> GetUniqueGrade(int StudentId, int EventId)
        {
            return await _appDbContext.GradesTable.Where(n => n.StudentId == StudentId & n.EventId == EventId).SingleOrDefaultAsync();
        }
        [HttpPost]
        public async Task<ActionResult> AddGrade(Grades grade)
        {
            // = new StudentsEvents() { StudentId = user.MatrikelNum, EventId = e.EventId };
            await _appDbContext.AddAsync(grade);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGrades), new { Id = grade.Id }, grade);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateGrade(Grades grade)
        {
            _appDbContext.GradesTable.Update(grade);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteGrade(int Id)
        {
            Grades? GradeToDelete = await _appDbContext.GradesTable.Where(n => n.Id == Id).FirstOrDefaultAsync();
            if (GradeToDelete != null)
            {
                _appDbContext.GradesTable.Remove(GradeToDelete);
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
