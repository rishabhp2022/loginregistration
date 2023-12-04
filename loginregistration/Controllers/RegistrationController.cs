using loginregistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace loginregistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly UserContext _dbContext;

        public RegistrationController(UserContext dbContext)
        {
            _dbContext = dbContext;
        }

        //private readonly List<Login>registeredUser=new List<Login>();

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        //{
        //    if (_dbContext.Users == null)
        //    {
        //        return NotFound();
        //    }
        //    return await _dbContext.Users.ToListAsync();
        //}

        //[HttpGet]
        //public async Task<ActionResult<User>> GetUsers(int id)
        //{
        //    if (_dbContext.Users == null)
        //    {
        //        return NotFound();
        //    }
        //    var User = await _dbContext.Users.FindAsync(id);
        //    if (User == null)
        //    {
        //        return NotFound();

        //    }
        //    return User;
        //}

        [HttpPost]
        [Route("PostUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            //Response res = new Response();
            var userRegister = _dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userRegister == null)
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                return Ok(user);
            }
            else {
                return Ok("Already exists");
            }
 

        }


        [HttpPost]
        [Route("Login")]
        public Response Login( Login user)
        {
            Response res = new Response();

            res.IsSucess = true;

            res.Message = "Login Successfully";

            var userlogin = _dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            
                if (userlogin == null)
                {
                    res.Message = "User does not exist";
                    res.IsSucess = false;

                }
            return res;

            }

        }

    }

