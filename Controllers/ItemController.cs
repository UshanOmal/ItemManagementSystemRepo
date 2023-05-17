using ItemManagmentSystem.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetItems()
        {
            return Ok(dbContext.Items.ToList());
        }
    }
}
