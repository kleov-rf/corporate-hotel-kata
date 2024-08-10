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

    public void AddHotel(Hotel newHotel)
    {
        _hotels.Add(newHotel);
    }
}