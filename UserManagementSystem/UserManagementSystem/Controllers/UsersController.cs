using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementSystem.Models;

namespace UserManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<User> Get()
        {
            using(var context = new UserDBContext())
            {
                return context.Users.ToList();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] User u)
        {
            using (var context = new UserDBContext())
            {
                if(u == null)
                {
                    return BadRequest();
                }
                else
                {
                    context.Users.Add(u);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
