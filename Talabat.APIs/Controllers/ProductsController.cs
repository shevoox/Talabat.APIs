using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Error;
using Talabat.Core.Entityies;
using Talabat.Core.ProductSpecs;
using Talabat.Core.Repositories;
namespace Talabat.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenaricRepository<Product> _ProductRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenaricRepository<Product> ProductRepo, IMapper mapper)
        {
            _ProductRepo = ProductRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProduct()
        {
            var spec = new ProductWithBrandAndCategorySpecification();
            var products = await _ProductRepo.GetAllWithSpecAsync(spec);
            if (products == null) return BadRequest();
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecification(id);
            var product = await _ProductRepo.GetWithSpecAsync(spec);
            if (product == null) return NotFound(new ApiErrorResponce(404));
            return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
        }
    }
}
