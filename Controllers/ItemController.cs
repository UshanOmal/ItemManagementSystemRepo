using ItemManagmentSystem.Data;
using ItemManagmentSystem.DTO;
using ItemManagmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItemManagmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public ItemController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            return Ok(await dbContext.Items.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddItems(AddItem addItem)
        {
            var item = new Item()
            {
                TaskName = addItem.TaskName,
                TaskDescription = addItem.TaskDescription,
                Status = addItem.Status,
                Attachement = addItem.Attachement
            };
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return Ok(item);
        }
    }
}
