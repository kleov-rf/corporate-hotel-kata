using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure.Persistence;
using CorporateHotel.HotelManagement.Infrastructure.Persistence.Models;
using CorporateHotel.Tests.Helpers;
using JetBrains.Annotations;
using MongoDB.Driver;
using Moq;

namespace CorporateHotel.Tests.HotelManagement.Infrastructure;

[TestSubject(typeof(MongoDbHotelRepository))]
public class MongoDbHotelRepositoryShould
{

    [Fact]
    public async Task FindExistingHotel()
    {
        const string hotelName = "Hotel Name";
        var hotelStringId = Helpers.HotelIdHelper.GenerateNewId();
        var hotelId = new HotelId(hotelStringId);
        var existingHotel = new Hotel(hotelId, hotelName);
        var currentHotels = new List<MongoHotel> {MongoHotel.FromDomain(existingHotel)};
        var mongoDatabase = new Mock<IMongoDatabase>();
        var mongoDbHotelRepository = new MongoDbHotelRepository(mongoDatabase.Object);
        var hotelCollection = new Mock<IMongoCollection<MongoHotel>>();
        var asyncCursor = new Mock<IAsyncCursor<MongoHotel>>();
        
        asyncCursor.Setup(cursor => 
                cursor.Current)
            .Returns(currentHotels);

        hotelCollection.Setup(collection =>
                collection.FindAsync(
                    It.IsAny<FilterDefinition<MongoHotel>>(),
                    It.IsAny<FindOptions<MongoHotel, MongoHotel>>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(asyncCursor.Object);
        
        mongoDatabase.Setup(database => 
            database.GetCollection<MongoHotel>("Hotels", null))
            .Returns(hotelCollection.Object);
        
        var foundHotel = await mongoDbHotelRepository.FindHotelBy(hotelId);
        
        Assert.Equal(existingHotel, foundHotel);
    }

    [Fact]
    public async Task AddNewHotel()
    {
        const string newHotelName = "Hotel Name";
        var newHotelId = HotelIdHelper.GenerateNewId();
        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        
        var mongoDatabase = new Mock<IMongoDatabase>();
        var mongoDbHotelRepository = new MongoDbHotelRepository(mongoDatabase.Object);
        var hotelCollection = new Mock<IMongoCollection<MongoHotel>>();
        
        mongoDatabase.Setup(database => 
                database.GetCollection<MongoHotel>("Hotels", null))
            .Returns(hotelCollection.Object);
        
        await mongoDbHotelRepository.AddHotel(newHotel);
        
        hotelCollection.Verify(collection => 
            collection.InsertOneAsync(MongoHotel.FromDomain(newHotel), null, default));
    }
}