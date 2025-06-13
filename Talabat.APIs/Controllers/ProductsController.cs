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
        private readonly IGenaricRepository<ProductBrand> _brandRepo;
        private readonly IGenaricRepository<ProductCategory> _categoryRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenaricRepository<Product> ProductRepo,
            IGenaricRepository<ProductBrand> BrandRepo,
            IGenaricRepository<ProductCategory> CategoryRepo,
            IMapper mapper)
        {
            _ProductRepo = ProductRepo;
            _brandRepo = BrandRepo;
            _categoryRepo = CategoryRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProduct(string? sort, int? brandId, int? categoryId)
        {
            var spec = new ProductWithBrandAndCategorySpecification(sort, brandId, categoryId);
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
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
        {
            var brands = await _brandRepo.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("Categories")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetCategories()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }
    }
}
