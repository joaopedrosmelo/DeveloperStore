using Moq;
using MediatR;
using DeveloperStore.Commands;
using DeveloperStore.Events;
using DeveloperStore.Handlers;
using DeveloperStore.Models;
using DeveloperStore.Repositories;

public class CancelSaleHandlerTests
{
    [Fact]
    public async Task Handle_ShouldCancelSaleAndPublishEvent()
    {
        // Arrange
        var sale = new Sale { Id = 1, IsCancelled = false };
        var mockRepository = new Mock<ISaleRepository>();
        var mockMediator = new Mock<IMediator>();

        mockRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(sale);

        var handler = new CancelSaleHandler(mockRepository.Object, mockMediator.Object);

        // Act
        await handler.Handle(new CancelSaleCommand(1), CancellationToken.None);

        // Assert
        Assert.True(sale.IsCancelled);
        mockRepository.Verify(r => r.UpdateAsync(sale), Times.Once);
        mockMediator.Verify(m => m.Publish(It.IsAny<SaleCancelledEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}