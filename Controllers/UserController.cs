using ItemManagmentSystem.Data;
using ItemManagmentSystem.DTO;
using ItemManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemManagmentSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly ApplicationDbContext dbContext;
    public UserController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await dbContext.Users.ToListAsync());
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetUser([FromRoute] Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> AddUsers(AddUserDTO addUser)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            UserName = addUser.UserName,
            Password = addUser.Password,
        };
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();

        return Ok(user);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserDTO updateUserDTO)
    {
        var user = await dbContext.Users.FindAsync(id);
        if (user != null)
        {
            user.UserName = updateUserDTO.UserName;
            user.Password = updateUserDTO.Password;

            await dbContext.SaveChangesAsync();
            return Ok(user);
        }

        return NotFound();
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        if (user != null)
        {
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return Ok(user);
        }
        return NotFound();
    }
}
