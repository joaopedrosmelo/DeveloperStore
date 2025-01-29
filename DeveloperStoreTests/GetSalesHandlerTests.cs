using Moq;
using DeveloperStore.Handlers;
using DeveloperStore.Models;
using DeveloperStore.Queries;
using DeveloperStore.Repositories;

public class GetSalesHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnPaginatedSales()
    {
        // Arrange
        var sales = new List<Sale>
        {
            new Sale { Id = 1 },
            new Sale { Id = 2 }
        };

        var mockRepository = new Mock<ISaleRepository>();
        mockRepository.Setup(r => r.GetSalesAsync(1, 10, "saleNumber", ""))
                      .ReturnsAsync((sales, 2));

        var handler = new GetSalesHandler(mockRepository.Object);

        // Act
        var (result, totalItems) = await handler.Handle(new GetSalesQuery(1, 10, "saleNumber", ""), CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(2, totalItems);
    }
}