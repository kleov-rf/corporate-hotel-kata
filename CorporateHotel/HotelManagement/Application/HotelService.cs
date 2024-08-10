using CorporateHotel.HotelManagement.Domain;

namespace CorporateHotel.HotelManagement.Application;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _hotelRepository;

    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public void AddHotel(HotelId hotelId, string newHotelName)
    {
        var newHotel = new Hotel(hotelId, newHotelName);
        _hotelRepository.AddHotel(newHotel);
    }
}