using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<IEnumerable<AppUser>> GetUsers() 
    {
      var users = _context.Users.ToList();

      return users;
    }

    [HttpGet("{id}")]
    public ActionResult<AppUser> GetUser(int id)
    {
      var user = _context.Users.Find(id);

      return user;
    }
  }
}