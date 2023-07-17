using FluentValidation;

namespace ShopApi.Dtos.BrandDto
{
    public class BrandGelDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class BrandGetAllDtoValidatior : AbstractValidator<BrandGelDto>
    {

        public BrandGetAllDtoValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
        }
    }
}
