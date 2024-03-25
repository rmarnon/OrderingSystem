using Ordering.System.Api.Entities;

namespace Ordering.System.Api.Helper
{
    internal static class CalculateHelper
    {
        internal static double GetTotalValue(IEnumerable<OrderItem> products)
        {
            return products.Sum(product => product.SubTotal);
        }

        internal static uint GetTotalQuantity(IEnumerable<OrderItem> items)
        {
            return items.Aggregate(0U, (total, item) => total + item.Quantity);
        }
    }
}
