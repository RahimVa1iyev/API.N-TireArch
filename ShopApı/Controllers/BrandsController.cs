using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Core.Entities;
using ShopApi.Core.Repositories;
using ShopApi.Data;
using ShopApi.Dtos.BrandDto;

namespace ShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsController( IBrandRepository brandRepository )
        {
            _brandRepository = brandRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<BrandGetDto> Get(int id)
        {
            var brand = _brandRepository.Get(x=>x.Id==id);

            if (brand == null) return NotFound();

            BrandGetDto brandDto = new()
            {
                Name = brand.Name
            };

            return Ok(brandDto);
            
        }

        [HttpGet("all")]
        public ActionResult<List<BrandGelDto>> GetAll()
        {
            var brandGetAllDto = _brandRepository.GetQueryable(x=>true).Select(x => new BrandGelDto { Id = x.Id, Name = x.Name }).ToList();

            return Ok(brandGetAllDto);
        }

        [HttpPost("")]
        public IActionResult Create(BrandCreateDto brandDto)
        {
            if (_brandRepository.IsExist(x=>x.Name==brandDto.Name))
            {
                ModelState.AddModelError("", "Name is taken");
                return BadRequest(ModelState);
            }

            Brand brand = new Brand
            {
                Name = brandDto.Name,
            };

            _brandRepository.Add(brand);
            _brandRepository.IsCommit();

            return StatusCode(201, new { id = brand.Id });
           
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id , BrandEditDto brandDto )
        {
            var brand = _brandRepository.Get(x=>x.Id==id);
            if (brand == null) return NotFound();

            if (brand.Name != brandDto.Name && _brandRepository.IsExist(x=>x.Name == brandDto.Name))
            {
                ModelState.AddModelError("", "Name is taken");
                return BadRequest(ModelState);
            }
            
            brand.Name = brandDto.Name;

           _brandRepository.IsCommit();

            return NoContent();
            

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var brand = _brandRepository.Get(x=>x.Id == id);

            if (brand == null) return NotFound();

            _brandRepository.Delete(brand);
            _brandRepository.IsCommit();

            return NoContent();

        }

    }
}
