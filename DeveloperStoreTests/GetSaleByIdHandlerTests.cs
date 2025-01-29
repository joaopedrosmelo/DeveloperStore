using Moq;
using DeveloperStore.Handlers;
using DeveloperStore.Models;
using DeveloperStore.Queries;
using DeveloperStore.Repositories;

public class GetSaleByIdHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnSale()
    {
        // Arrange
        var sale = new Sale { Id = 1 };
        var mockRepository = new Mock<ISaleRepository>();
        mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(sale);

        var handler = new GetSaleByIdHandler(mockRepository.Object);

        // Act
        var result = await handler.Handle(new GetSaleByIdQuery(1), CancellationToken.None);

        // Assert
        Assert.Equal(sale, result); // Verifica se a venda foi retornada
    }
}