using Core.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Core.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, null);
            action.Should().NotThrow<Core.Domain.Validators.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 1, 1, null);
            action.Should().Throw<Core.Domain.Validators.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 1, 1, null);
            action.Should().Throw<Core.Domain.Validators.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 1, 1, null);
            action.Should().Throw<Core.Domain.Validators.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, null);
            action.Should().NotThrow<Core.Domain.Validators.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, 1, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 1, value, null);
            action.Should().Throw<Core.Domain.Validators.DomainExceptionValidation>().WithMessage("Invalid stock value");
        }
    }
}
