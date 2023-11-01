
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers;

[Authorize]
public class UserController : BaseApiController
{
    private readonly DataContext _context;
    public UserController(DataContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _context.AppUsers.ToListAsync();
        return users;
    }

    [HttpGet("{id}")] //app/user/2
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.AppUsers.FindAsync(id);
    }


}
