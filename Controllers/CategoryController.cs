using AssetManagmentSystem2.Data;
using AssetManagmentSystem2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagmentSystem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public CategoryController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            if (_dbContext.Category == null)
            {
                return NotFound();
            }
            return await _dbContext.Category.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetAsset(int id, Category category)
        {
            if (_dbContext.Category == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;

        }


        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _dbContext.Category.Add(category);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);

        }

        private object GetCategory()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult> PutAsset(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(category).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok();
        }
        private bool CategoryAvailable(int id)
        {
            return (_dbContext.Category?.Any(x => x.Id == id)).GetValueOrDefault();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id, Category category)
        {
            if (_dbContext.Category == null)
            {
                return NotFound();
            }
            var category1 = await _dbContext.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _dbContext.Category.Remove(category);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}