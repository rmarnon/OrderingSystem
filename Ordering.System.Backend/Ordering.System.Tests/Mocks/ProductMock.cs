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
    }
}
