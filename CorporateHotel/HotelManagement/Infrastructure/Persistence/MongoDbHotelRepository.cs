using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure.Persistence.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace CorporateHotel.HotelManagement.Infrastructure.Persistence;

public class MongoDbHotelRepository : IHotelRepository
{
    private readonly IMongoDatabase _database;
    
    static MongoDbHotelRepository()
    {
        BsonClassMap.RegisterClassMap<Hotel>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(c => c.Id);
        });
    }

    public MongoDbHotelRepository(IMongoDatabase database)
    {
        _database = database;
    }
    
    public async Task AddHotel(Hotel newHotel)
    {
        var hotels = _database.GetCollection<MongoHotel>("Hotels");
        var mongoHotel = MongoHotel.FromDomain(newHotel);
        await hotels.InsertOneAsync(mongoHotel);
    }

    public async Task<Hotel?> FindHotelBy(HotelId hotelId)
    {
        var hotels = _database.GetCollection<MongoHotel>("Hotels");
        var filter = Builders<MongoHotel>.Filter.Eq(hotel => hotel.Id, hotelId.ToString());
        var foundMongoHotels = await hotels.FindAsync(filter);

        while (await foundMongoHotels.MoveNextAsync())
        {
            var mongoHotel = foundMongoHotels.Current.FirstOrDefault();
            if (mongoHotel != null)
                return mongoHotel.ToDomain();
        }

        return null;
    }
}