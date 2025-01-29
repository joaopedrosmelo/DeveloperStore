using DeveloperStore.Models;
using DeveloperStore.Utils;

public class SaleDiscountCalculatorTests
{
    [Fact]
    public void ApplyDiscounts_ShouldApply10PercentDiscount_WhenQuantityIsBetween4And9()
    {
        // Arrange
        var sale = new Sale
        {
            Items = new List<SaleItem>
            {
                new SaleItem { Quantity = 5, UnitPrice = 100 }
            }
        };

        // Act
        SaleDiscountCalculator.ApplyDiscounts(sale);

        // Assert
        Assert.Equal(0.10m, sale.Items[0].Discount);
        Assert.Equal(450, sale.TotalAmount);
    }

    [Fact]
    public void ApplyDiscounts_ShouldApply20PercentDiscount_WhenQuantityIsBetween10And20()
    {
        // Arrange
        var sale = new Sale
        {
            Items = new List<SaleItem>
            {
                new SaleItem { Quantity = 15, UnitPrice = 100 }
            }
        };

        // Act
        SaleDiscountCalculator.ApplyDiscounts(sale);

        // Assert
        Assert.Equal(0.20m, sale.Items[0].Discount);
        Assert.Equal(1200, sale.TotalAmount);
    }

    [Fact]
    public void ApplyDiscounts_ShouldThrowException_WhenQuantityIsAbove20()
    {
        // Arrange
        var sale = new Sale
        {
            Items = new List<SaleItem>
            {
                new SaleItem { Quantity = 25, UnitPrice = 100 }
            }
        };

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => SaleDiscountCalculator.ApplyDiscounts(sale));
        Assert.Equal("Cannot sell more than 20 identical items.", exception.Message);
    }
}