using AssetManagmentSystem2.Data;
using AssetManagmentSystem2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagmentSystem2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly DataContext _dbContext;

        public AssetController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asset>>> GetAssets()
        {
            if(_dbContext.Asset == null)
            {
                return NotFound();
            }
            return await _dbContext.Asset.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetAsset(int id, Asset asset)
        {
            if (_dbContext.Asset == null)
            {
                return NotFound();
            }
            var asset1 = await _dbContext.Asset.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            return asset;

        }
        
        
        [HttpPost]
        public async Task<ActionResult<Asset>> PostAsset(Asset asset)
        {
            _dbContext.Asset.Add(asset);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsset), new {id = asset.Id}, asset);

        }
        [HttpPut]
        public async Task<ActionResult> PutAsset(int id, Asset asset)
        {
            if(id != asset.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(asset).State =EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!AssetAvailable(id))
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
        private bool AssetAvailable(int id)
        {
            return (_dbContext.Asset?.Any(x => x.Id == id)).GetValueOrDefault();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(int id, Asset asset)
        {
            if (_dbContext.Asset == null)
            {
                return NotFound();
            }
            var asset1 = await _dbContext.Asset.FindAsync(id);
            if(asset == null)
            {
                return NotFound();
            }

            _dbContext.Asset.Remove(asset);

            await _dbContext.SaveChangesAsync(); 

            return Ok();
        }
    
}
}
