using CorporateHotel.HotelManagement.Domain;

namespace CorporateHotel.HotelManagement.Application;

public interface IHotelService
{
    Task AddHotel(HotelId hotelId, string newHotelName);
    Task<Hotel?> FindHotelBy(HotelId hotelId);
}