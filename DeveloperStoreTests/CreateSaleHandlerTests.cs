using DeveloperStore.Commands;
using DeveloperStore.Events;
using DeveloperStore.Handlers;
using DeveloperStore.Models;
using DeveloperStore.Repositories;
using MediatR;
using Moq;

public class CreateSaleHandlerTests
{
    [Fact]
    public async Task Handle_ShouldApplyDiscountsAndSaveSale()
    {
        // Arrange
        var sale = new Sale
        {
            Items = new List<SaleItem>
            {
                new SaleItem { Quantity = 5, UnitPrice = 100 }
            }
        };

        var mockRepository = new Mock<ISaleRepository>();
        var mockMediator = new Mock<IMediator>();

        var handler = new CreateSaleHandler(mockRepository.Object, mockMediator.Object);

        // Act
        var result = await handler.Handle(new CreateSaleCommand(sale), CancellationToken.None);

        // Assert
        mockRepository.Verify(r => r.AddAsync(sale), Times.Once);
        mockMediator.Verify(m => m.Publish(It.IsAny<SaleCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal(450, sale.TotalAmount);
    }
}