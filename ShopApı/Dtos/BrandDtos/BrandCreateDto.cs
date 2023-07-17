using FluentValidation;

namespace ShopApi.Dtos.BrandDto
{
    public class BrandCreateDto
    {
        public string Name { get; set; }
    }

    public class BrandCreateDtoValidatior : AbstractValidator<BrandCreateDto>
    {

        public BrandCreateDtoValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
        }
    }
}
