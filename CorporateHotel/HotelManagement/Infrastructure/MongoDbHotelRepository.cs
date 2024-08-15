using CorporateHotel.HotelManagement.Domain;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CorporateHotel.HotelManagement.Infrastructure;

public class MongoDbHotelRepository : IHotelRepository
{
    private readonly IMongoDatabase _database;
    
    static MongoDbHotelRepository()
    {
        BsonClassMap.RegisterClassMap<Hotel>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(c => c.HotelId);
        });
    }

    public MongoDbHotelRepository(IMongoDatabase database)
    {
        _database = database;
    }
    
    public Task AddHotel(Hotel newHotel)
    {
        throw new NotImplementedException();
    }

    public async Task<Hotel?> FindHotelBy(HotelId hotelId)
    {
        var hotels = _database.GetCollection<Hotel>("Hotels", null);
        var filter = Builders<Hotel>.Filter.Eq(hotel => hotel.HotelId, hotelId);
        var foundHotels = await hotels.FindAsync(filter);
        return foundHotels.Current?.FirstOrDefault();
    }
}