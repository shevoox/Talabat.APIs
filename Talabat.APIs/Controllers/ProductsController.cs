using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Error;
using Talabat.APIs.Helpers;
using Talabat.Core.Entityies;
using Talabat.Core.ProductSpecs;
using Talabat.Core.Repositories;
using Talabat.Core.Specifications;
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

        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProduct([FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductWithBrandAndCategorySpecification(specParams);
            var products = await _ProductRepo.GetAllWithSpecAsync(spec);
            if (products == null) return BadRequest();
            var data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products);
            var countSpec = new ProductWithFilterationForCountSpecifications(specParams);
            var count = await _ProductRepo.GetCountAsync(countSpec);
            return Ok(new Pagination<ProductToReturnDto>(specParams.PageIndex, specParams.PageSize, count, data));
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
