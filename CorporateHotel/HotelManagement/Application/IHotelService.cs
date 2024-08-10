using CorporateHotel.HotelManagement.Domain;

namespace CorporateHotel.HotelManagement.Application;

public interface IHotelService
{
    void AddHotel(HotelId hotelId, string newHotelName);
    Hotel FindHotelBy(HotelId hotelId);
}