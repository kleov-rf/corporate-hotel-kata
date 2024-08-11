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

    public async Task AddHotel(HotelId hotelId, string newHotelName)
    {
        var newHotel = new Hotel(hotelId, newHotelName);
        var hasFoundExistingHotelId = await _hotelRepository.FindHotelBy(hotelId) is not null;

        if (hasFoundExistingHotelId) throw new AlreadyExistingHotelException();

        await _hotelRepository.AddHotel(newHotel);
    }

    public async Task<Hotel?> FindHotelBy(HotelId hotelId)
    {
        return await _hotelRepository.FindHotelBy(hotelId);
    }
}