using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entityies;
using Talabat.Core.Repositories;

namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenaricRepository<Product> _ProductRepo;

        public ProductsController(IGenaricRepository<Product> ProductRepo)
        {
            _ProductRepo = ProductRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var product = await _ProductRepo.GetAllAsync();
            if (product == null) return BadRequest();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await _ProductRepo.GetAsync(id);
            if (product == null) return NotFound(new { Message = "Not Found", StatusCode = 404 });
            return Ok(product);
        }
    }
}
