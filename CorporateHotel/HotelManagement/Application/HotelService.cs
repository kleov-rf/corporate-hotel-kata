using CorporateHotel.HotelManagement.Domain;

namespace CorporateHotel.HotelManagement.Application;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepositoryObject;

    public HotelService(IHotelRepository hotelRepositoryObject)
    {
        _hotelRepositoryObject = hotelRepositoryObject;
    }

    public void AddHotel(HotelId hotelId, string newHotelName)
    {
        throw new NotImplementedException();
    }
}