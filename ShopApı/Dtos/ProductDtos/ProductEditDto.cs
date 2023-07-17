﻿using FluentValidation;

namespace ShopApi.Dtos.ProductDtos
{
    public class ProductEditDto
    {
        public int BrandId { get; set; }

        public string Name { get; set; }

        public decimal SalePrice { get; set; }

        public decimal CostPrice { get; set; }

    }

    public class ProductEditDtoValidator : AbstractValidator<ProductEditDto>
    {
        public ProductEditDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(35);
            RuleFor(x => x.SalePrice).GreaterThanOrEqualTo(x => x.CostPrice);
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.BrandId).GreaterThanOrEqualTo(1);


        }
    }
}
