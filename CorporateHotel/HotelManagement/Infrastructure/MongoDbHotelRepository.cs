using CorporateHotel.HotelManagement.Domain;
using MongoDB.Driver;

namespace CorporateHotel.HotelManagement.Infrastructure;

public class MongoDbHotelRepository : IHotelRepository
{
    private readonly IMongoDatabase _database;

    public MongoDbHotelRepository(IMongoDatabase database)
    {
        _database = database;
    }
    
    public Task AddHotel(Hotel newHotel)
    {
        throw new NotImplementedException();
    }

    public Task<Hotel?> FindHotelBy(HotelId hotelId)
    {
        throw new NotImplementedException();
    }
}