using asutus.api.Commands;
using asutus.api.Handlers;
using asutus.common.Model;
using asutus.domain.Data.Repositories;
using Moq;

namespace asutus.test.api.Handlers;

public class AsutusByKoodHandlerTests
{
    [Fact]
    public async Task Handle_EntityPresented_DtoObjectReturned()
    {
        // Arrange
        var mockRepository = new Mock<IAsutusRepository>();
        var code = "TEST";
        var asutusDto = new AsutusDto { Code = code, Name = "Test Name" };

        mockRepository.Setup(repo => repo.GetAsutusAsync(code, It.IsAny<CancellationToken>()))
            .ReturnsAsync(asutusDto);

        var handler = new AsutusByKoodHandler(mockRepository.Object);
        var query = new AsutusByKoodRequest(code);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(code, result.Code);
    }
}