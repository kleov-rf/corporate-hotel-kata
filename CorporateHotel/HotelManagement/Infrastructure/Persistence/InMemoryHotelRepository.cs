using CorporateHotel.HotelManagement.Domain;

namespace CorporateHotel.HotelManagement.Infrastructure;

public class InMemoryHotelRepository : IHotelRepository
{
    private readonly List<Hotel> _hotels;

    public InMemoryHotelRepository(List<Hotel> hotels)
    {
        _hotels = hotels;
    }

    public InMemoryHotelRepository()
    {
        _hotels = new List<Hotel>();
    }

    public Task AddHotel(Hotel newHotel)
    {
        _hotels.Add(newHotel);
        return Task.CompletedTask;
    }

    public Task<Hotel?> FindHotelBy(HotelId hotelId)
    {
        return Task.FromResult(_hotels.Find(hotel => hotel.IsIdentifiedBy(hotelId)));
    }
}