
using Moq;
using MediatR;
using DeveloperStore.Commands;
using DeveloperStore.Events;
using DeveloperStore.Handlers;
using DeveloperStore.Models;
using DeveloperStore.Repositories;

public class UpdateSaleHandlerTests
{
    [Fact]
    public async Task Handle_ShouldApplyDiscountsAndUpdateSale()
    {
        // Arrange
        var sale = new Sale
        {
            Id = 1,
            Items = new List<SaleItem>
            {
                new SaleItem { Quantity = 10, UnitPrice = 100 }
            }
        };

        var mockRepository = new Mock<ISaleRepository>();
        var mockMediator = new Mock<IMediator>();

        var handler = new UpdateSaleHandler(mockRepository.Object, mockMediator.Object);

        // Act
        await handler.Handle(new UpdateSaleCommand(sale), CancellationToken.None);

        // Assert
        mockRepository.Verify(r => r.UpdateAsync(sale), Times.Once);
        mockMediator.Verify(m => m.Publish(It.IsAny<SaleModifiedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal(800, sale.TotalAmount);
    }
}