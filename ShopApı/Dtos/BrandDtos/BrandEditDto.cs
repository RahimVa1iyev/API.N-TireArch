using FluentValidation;

namespace ShopApi.Dtos.BrandDto
{
    public class BrandEditDto
    {
        public string Name { get; set; }
    }

    public class BrandEditDtoValidatior : AbstractValidator<BrandEditDto>
    {

        public BrandEditDtoValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
        }
    }
}
