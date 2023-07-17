using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Core.Entities;
using ShopApi.Core.Repositories;
using ShopApi.Data;
using ShopApi.Dtos.ProductDtos;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;

        public ProductsController(ShopDbContext context , IProductRepository productRepository, IBrandRepository brandRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        [HttpPost("")]

        public IActionResult Create(ProductCreateDto productDto)
        {
            if (!_brandRepository.IsExist(x=>x.Id==productDto.BrandId))
            {
                ModelState.AddModelError("", $"Brand  not found by Id {productDto.BrandId}");
                return BadRequest(ModelState);
            }

            Product product = new Product
            {
                Name = productDto.Name,
                SalePrice = productDto.SalePrice,
                CostPrice = productDto.CostPrice,
                BrandId = productDto.BrandId,
                CreatedAt = DateTime.UtcNow.AddHours(4),
                ModifiedAt = DateTime.UtcNow.AddHours(4)

            };

            _productRepository.Add(product);
            _productRepository.IsCommit();


            return StatusCode(201, new { id = product.Id });
        }

        [HttpGet("{id}")]
        public ActionResult<ProductGetDto> Get(int id)
        {
            var product = _productRepository.Get(x => x.Id == id,"Brand");
            if(product == null) return NotFound();

            ProductGetDto productDto = new ProductGetDto()
            {
                Name = product.Name,
                SalePrice = product.SalePrice,
                CostPrice = product.CostPrice,

                Brand = new BrandInProductGetDto
                {
                    Id = product.BrandId,
                    Name = product.Brand.Name
                }
            };

            return Ok(productDto);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id , ProductEditDto productDto)
        {
            var product = _productRepository.Get(x => x.Id == id,"Brand");

            if( product == null) return NotFound();

            if (!_brandRepository.IsExist(x=>x.Id==productDto.BrandId))
            {
                ModelState.AddModelError("", $"Brand not found by Id {productDto.BrandId}");
                return BadRequest(ModelState);
            }


            product.Name = productDto.Name;
            product.SalePrice = productDto.SalePrice;
            product.CostPrice = productDto.CostPrice;
            product.BrandId = productDto.BrandId;

            _productRepository.IsCommit();






            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productRepository.Get(x => x.Id == id);

            if (product == null) return NotFound();

            _productRepository.Delete(product);
            _productRepository.IsCommit();

            return NoContent();

        }


    }
}
