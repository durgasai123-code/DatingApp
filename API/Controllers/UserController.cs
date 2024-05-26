using System.Reflection.Metadata.Ecma335;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] //api/user
public class UserController : ControllerBase
{
    private readonly DataContext _context;
    public UserController(DataContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUsers>>> GetUsers(){
        var users = await _context.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id}")] //api/user/1
    public async Task<ActionResult<AppUsers>> GetUser(int id)
    {
        if(id>= 0)
        {
            var user = await _context.Users.FindAsync(id);
            if(user!= null){
                return user;
            }
            else{
                return NotFound();
            }
        }
        else{
            return NotFound();
        }
    } 


}
