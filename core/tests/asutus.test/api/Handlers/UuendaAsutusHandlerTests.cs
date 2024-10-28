using asutus.bl.Commands;
using asutus.bl.Handlers;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using Moq;

namespace asutus.test.api.Handlers;

public class UuendaAsutusHandlerTests
{
    [Fact]
    public async Task Handle_ValidUpdateCommand_RepositoryWriteIsCalled()
    {
        // Arrange
        var mockRepository = new Mock<IAsutusRepository>();
        var handler = new UuendaAsutusHandler(mockRepository.Object);
        var asutusDto = new AsutusDto { Code = "TEST", Name = "Updated Name" };
        var command = new UuendaAsutusRequest(asutusDto);

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepository.Verify(repo => 
            repo.AddOrUpdateAsync(
                It.Is<AsutusDto>(a => a.Code == asutusDto.Code && a.Name == asutusDto.Name),
                It.IsAny<CancellationToken>()
                ),
            Times.Once);
    }
}