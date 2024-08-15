using MongoDB.Driver;

namespace CorporateHotel.Tests.Acceptance.Config;

public class MongoDbTestBase : IClassFixture<MongoDbFixture>
{
    protected readonly IMongoDatabase _database;

    public MongoDbTestBase(MongoDbFixture fixture)
    {
        _database = fixture.Database;
    }
}