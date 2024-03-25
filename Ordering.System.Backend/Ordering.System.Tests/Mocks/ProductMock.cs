using Ordering.System.Api.Models;
using Ordering.System.Api.Entities;

namespace Ordering.System.Tests.Mocks
{
    internal static class ProductMock
    {
        internal static Product GetValidProduct()
        {
            return new()
            {
                Code = "xyz",
                Value = 37.99,
                Description = "some description",
                RegistrationDate = new DateTime(1982, 04, 29)
            };
        }

        internal static ProductInputModel GetInvalidProduct()
        {
            return new()
            {
                Code = string.Empty,
                Description = string.Empty,
                Value = -3.14,
                RegistrationDate = DateTime.Today.AddDays(1)
            };
        }

        internal static ProductViewModel GetValidProductsDto()
        {
            return new()
            {
                Code = "xyz",
                Value = 37.99,
                Description = "some description",
                RegistrationDate = DateTime.Today.AddDays(-1)
            };
        }

        internal static Product GetUpdatedProduct(Product product)
        {
            product.Code = "abc";
            product.Value = 79.99;
            product.Description = "other description";
            product.RegistrationDate = DateTime.Now.AddDays(-5);
            return product;
        }

        internal static ProductInputModel GetValidInputProduct()
        {
            return new()
            {
                Code = "xyz",
                Value = 37.99,
                Description = "some description",
                RegistrationDate = new DateTime(1982, 04, 29)
            };
        }
    }
}
