using AFStudiumDBAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AFStudiumDBAPI.Domain.Entities;



namespace AFStudiumDBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly AppDbContext _demoDbContext;
        public UserController(AppDbContext demoDbContext)
        {
            _demoDbContext = demoDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _demoDbContext.Userstable;
        }
        [HttpGet("{MatrikelNum}")]
        public async Task<ActionResult<User?>> GetUsersByMatrikelNum(int MatrikelNum)
        {
            return await _demoDbContext.Userstable.Where(n => n.MatrikelNum == MatrikelNum).SingleOrDefaultAsync();
        }
        [HttpGet("{Email},{Password}")]
        public async Task<ActionResult<User?>> GetUsersByEmailNPass(string Email, string Password)
        {
            return await _demoDbContext.Userstable.Where(n => n.Email == Email & n.Password == Password).FirstOrDefaultAsync();
        }
        [HttpPost]
        public async Task<ActionResult> PostUser(User user)
        {
            await _demoDbContext.AddAsync(user);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { MatrikelNum = user.MatrikelNum }, user);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(User user)
        {
            _demoDbContext.Userstable.Update(user);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{MatrikelNum}")]
        public async Task<ActionResult> Delete(int MatrikelNum)
        {
            var UserGetByMatrikelNumResult = await GetUsersByMatrikelNum(MatrikelNum);
            if (UserGetByMatrikelNumResult.Value is null)
                return NotFound();
            _demoDbContext.Remove(UserGetByMatrikelNumResult.Value);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
