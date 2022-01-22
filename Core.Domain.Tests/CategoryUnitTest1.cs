using Core.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace Core.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<Core.Domain.Validators.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<Core.Domain.Validators.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<Core.Domain.Validators.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimun 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Core.Domain.Validators.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }
    }
}
