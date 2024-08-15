using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure;
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
        var currentHotels = new List<Hotel> {existingHotel};
        var mongoDatabase = new Mock<IMongoDatabase>();
        var mongoDbHotelRepository = new MongoDbHotelRepository(mongoDatabase.Object);
        var hotelCollection = new Mock<IMongoCollection<Hotel>>();
        var asyncCursor = new Mock<IAsyncCursor<Hotel>>();
        
        asyncCursor.Setup(cursor => 
                cursor.Current)
            .Returns(currentHotels);

        hotelCollection.Setup(collection =>
                collection.FindAsync(
                    It.IsAny<FilterDefinition<Hotel>>(),
                    It.IsAny<FindOptions<Hotel, Hotel>>(),
                    It.IsAny<CancellationToken>()))
            .ReturnsAsync(asyncCursor.Object);
        
        mongoDatabase.Setup(database => 
            database.GetCollection<Hotel>("Hotels", null))
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
        var hotelCollection = new Mock<IMongoCollection<Hotel>>();
        
        mongoDatabase.Setup(database => 
                database.GetCollection<Hotel>("Hotels", null))
            .Returns(hotelCollection.Object);
        
        await mongoDbHotelRepository.AddHotel(newHotel);
        
        hotelCollection.Verify(collection => collection.InsertOneAsync(newHotel, null, default));
    }
}