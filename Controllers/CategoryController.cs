using Dolgozat2024._10._22.DbContext;
using Dolgozat2024._10._22.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dolgozat2024._10._22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categoriesss = _context.Categories.ToList();
            return Ok(categoriesss);
        }
    }
}
