using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todolist.Models;

namespace todolist.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly TodolistContext _dbcontext;

        public UserController(TodolistContext dbcontext)
        {
            _dbcontext = dbcontext;
        }




   





        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Email == userObj.Email && x.Password == userObj.Password);

            if (user == null)
                return NotFound(new { Message = "User not found" });

            return Ok(new
            {
                Message = "Login Success"
            });
        }




        [HttpPost("register")]
        public async   Task<IActionResult> RegisterUser([FromBody] User userObj) {



            userObj.Iduser = Guid.NewGuid();
            if(userObj==null)
                return BadRequest();

            await _dbcontext.Users.AddAsync(userObj);
            await _dbcontext.SaveChangesAsync();

            return Ok(
                 new
                 {
                     Message = "wa hahowa tzad "
                 }
                ) ;



        }
    }


}
