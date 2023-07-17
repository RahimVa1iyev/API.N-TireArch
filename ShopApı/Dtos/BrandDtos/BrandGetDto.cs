using FluentValidation;

namespace ShopApi.Dtos.BrandDto
{
    public class BrandGetDto
    {
        public string Name { get; set; }
    }

    public class BrandGetDtoValidatior : AbstractValidator<BrandGelDto>
    {

        public BrandGetDtoValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
        }
    }
}
