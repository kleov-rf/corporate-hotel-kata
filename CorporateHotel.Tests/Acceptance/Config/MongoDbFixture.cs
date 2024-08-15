﻿using MongoDB.Driver;
using Testcontainers.MongoDb;

namespace CorporateHotel.Tests.Acceptance.Config;

public class MongoDbFixture : IAsyncLifetime
{
    public MongoDbContainer MongoDbContainer;
    public IMongoDatabase Database;

    public async Task InitializeAsync()
    {
        MongoDbContainer = new MongoDbBuilder().WithCleanUp(true).Build();
        await MongoDbContainer.StartAsync();
        var client = new MongoClient(MongoDbContainer.GetConnectionString());
        Database = client.GetDatabase("TestDatabase");
    }

    public async Task DisposeAsync()
    {
        await MongoDbContainer.StopAsync();
    }
}