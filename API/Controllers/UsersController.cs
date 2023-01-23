using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")] // localhost:5001/api/users
  public class UsersController : ControllerBase
  {
    private readonly DataContext _context;

    // "ctor" + TAB: to auto-generate constructor template
    // CTRL + . (on context parameter to add field): 
    public UsersController(DataContext context)
    {
      // Use of underscore here to reference private fields
      // ... instead of this.context
      _context = context;
    }

    [HttpGet]
    // Add "async" keyword and wrap return as a task to make this method asyncronous
    // allows for this server to handle multiple requests
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() 
    {
      // "await" keyword and change ToList() to ToListAsync() to wait on return.
      var users = await _context.Users.ToListAsync();

      return users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
      return await _context.Users.FindAsync(id);
    }
  }
}