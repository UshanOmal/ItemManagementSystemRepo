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
        public async Task<IActionResult> GetAllItems(string Status)
        {
            return Ok(await dbContext.Items.Where(x => x.Status == Status).ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            var item = await dbContext.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddItems(AddItemDTO addItem)
        {
            var item = new Item()
            {
                Id = Guid.NewGuid(),
                TaskName = addItem.TaskName,
                TaskDescription = addItem.TaskDescription,
                Status = addItem.Status,
                Attachement = addItem.Attachement
            };
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();

            return Ok(item);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateItem([FromRoute] Guid id, UpdateItemDTO updateTimeDTO)
        {
            var item = await dbContext.Items.FindAsync(id);
            if (item != null)
            {
                item.TaskName = updateTimeDTO.TaskName;
                item.TaskDescription = updateTimeDTO.TaskDescription;
                item.Status = updateTimeDTO.Status;
                item.Attachement = updateTimeDTO.Attachement;

                await dbContext.SaveChangesAsync();
                return Ok(item);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteItem([FromRoute] Guid id)
        {
            var item = await dbContext.Items.FindAsync(id);
            if (item != null)
            {
                dbContext.Items.Remove(item);
                await dbContext.SaveChangesAsync();
                return Ok(item);
            }
            return NotFound();
        }
    }
}
