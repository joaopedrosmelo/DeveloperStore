using DeveloperStore.Models;

namespace DeveloperStore.Utils
{
    public static class SaleDiscountCalculator
    {
        public static void ApplyDiscounts(Sale sale)
        {
            foreach (var item in sale.Items)
            {
                if (item.Quantity > 20)
                {
                    throw new InvalidOperationException("Cannot sell more than 20 identical items.");
                }

                if (item.Quantity >= 10)
                {
                    item.Discount = 0.20m;
                }
                else if (item.Quantity >= 4)
                {
                    item.Discount = 0.10m;
                }
                else
                {
                    item.Discount = 0;
                }

                item.TotalItemAmount = item.Quantity * item.UnitPrice * (1 - item.Discount);
            }

            sale.TotalAmount = sale.Items.Sum(i => i.TotalItemAmount);
        }
    }
}
