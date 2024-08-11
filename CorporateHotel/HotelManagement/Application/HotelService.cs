using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Domain.Exception;

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
        var hasFoundExistingHotelId = _hotelRepository.FindHotelBy(hotelId) is not null;

        if (hasFoundExistingHotelId) throw new AlreadyExistingHotelException();

        _hotelRepository.AddHotel(newHotel);
    }

    public Hotel FindHotelBy(HotelId hotelId)
    {
        return _hotelRepository.FindHotelBy(hotelId);
    }
}