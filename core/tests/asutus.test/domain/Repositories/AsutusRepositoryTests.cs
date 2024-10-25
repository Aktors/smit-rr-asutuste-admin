using asutus.common.Model;
using asutus.domain.Data;
using asutus.domain.Data.Repositories;
using asutus.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace asutus.test.domain.Repositories;

public class AsutusRepositoryTests
{ 
    private static readonly DateTime CurrentDateTime = new(2020, 01, 01);
    private const String Group1 = "TT";
    private const String Group2 = "BB";

    private static readonly List<Asutus> TestAsutused =
    [
        new Asutus { Code = Group1 + "1", Name = "Name A", StartDate = CurrentDateTime.AddDays(-1) },
        new Asutus { Code = Group1 + "2", Name = "Name B", StartDate = CurrentDateTime },
        new Asutus { Code = Group1 + "3", Name = "Name C", StartDate = CurrentDateTime.AddDays(1) },

        new Asutus { Code = Group2 + "1", Name = "Name BA", StartDate = CurrentDateTime.AddDays(-1) },
        new Asutus { Code = Group2 + "2", Name = "Name BB", StartDate = CurrentDateTime }
    ];
    
    [Fact]
    public async Task AddOrUpdateAsync_EntityIsNotPresented_EntityAddedToContext()
    {
        // Arrange
        ResetInMemoryDatabase();
        var options = CreateInMemoryDatabaseOptions();
        await using var context = new AsutusContext(options);
        var repository = new DbAsutusRepository(context);

        var asutusDto = new AsutusDto { Code = "TEST", Name = "Test Name" };

        // Act
        await repository.AddOrUpdateAsync(asutusDto);
        var result = await repository.GetAsutusAsync("TEST");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(asutusDto.Code, result.Code);
        Assert.Equal(asutusDto.Name, result.Name);
    }
    
    [Fact]
    public async Task AddOrUpdateAsync_EntityIsPresented_EntityUpdatedInContext()
    {
        // Arrange
        ResetInMemoryDatabase();
        var options = CreateInMemoryDatabaseOptions();
        var existingRecord = new Asutus { Code = "TEST", Name = "Old Name" };
        var updatedDto = new AsutusDto { Code = existingRecord.Code, Name = "Updated Name" };

        await using (var context = new AsutusContext(options))
        {
            context.Asutused.Add(existingRecord);
            await context.SaveChangesAsync();
        }

        await using (var context = new AsutusContext(options))
        {
            var repository = new DbAsutusRepository(context);

            // Act
            await repository.AddOrUpdateAsync(updatedDto);
            var updatedRecord = await repository.GetAsutusAsync("TEST");

            // Assert
            Assert.NotNull(updatedRecord);
            Assert.Equal(existingRecord.Code, updatedRecord.Code);
            Assert.Equal(updatedDto.Name, updatedRecord.Name);
        }
    }
    
    [Fact]
    public async Task SearchAsync_QueryWithGroup1Code_FirstGroupEntitiesReturned()
    {
        // Arrange
        ResetInMemoryDatabase();
        var options = CreateInMemoryDatabaseOptions();
        await using (var context = new AsutusContext(options))
        {
            context.Asutused.AddRange(TestAsutused);
            await context.SaveChangesAsync();
        }

        var query = new AsutusteQueryDto { Code = Group1 };

        await using (var context = new AsutusContext(options))
        {
            var repository = new DbAsutusRepository(context);

            // Act
            var result = await repository.SearchAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result);
            Assert.Equal(3, result.Total);
        }
    }
    
    [Fact]
    public async Task SearchAsync_QueryWithGroup1CodeAndDateSort_DateSortedFirstGroupEntitiesReturned()
    {
        // Arrange
        ResetInMemoryDatabase();
        var options = CreateInMemoryDatabaseOptions();
        using (var context = new AsutusContext(options))
        {
            context.Asutused.AddRange(TestAsutused);
            await context.SaveChangesAsync();
        }

        var query = new AsutusteQueryDto { Code = Group1 , 
            Pagination = new Pagination()
            {
                SortBy = nameof(AsutusDto.StartDate),
                SortOrder = "desc"
            }
        };

        await using (var context = new AsutusContext(options))
        {
            var repository = new DbAsutusRepository(context);

            // Act
            var result = await repository.SearchAsync(query);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.Equal(3, result.Total);
            Assert.True(result.Result[0].StartDate >= result.Result[1].StartDate);
            Assert.True(result.Result[1].StartDate >= result.Result[2].StartDate);
        }
    }
    
    private DbContextOptions<AsutusContext> CreateInMemoryDatabaseOptions()
    {
        return new DbContextOptionsBuilder<AsutusContext>()
            .UseInMemoryDatabase(databaseName: "AsutusTestDb")
            .Options;
    }
    
    private void ResetInMemoryDatabase()
    {
        using (var context = new AsutusContext(CreateInMemoryDatabaseOptions()))
        {
            context.Database.EnsureDeleted();
        }
    }
    
}