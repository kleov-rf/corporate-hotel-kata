using CorporateHotel.HotelManagement.Domain;

namespace CorporateHotel.HotelManagement.Infrastructure;

public class InMemoryHotelRepository : IHotelRepository
{
    public InMemoryHotelRepository(IEnumerable<Hotel> hotels)
    {
    }

    public InMemoryHotelRepository()
    {
    }

    public void AddHotel(Hotel newHotel)
    {
        throw new NotImplementedException();
    }
}