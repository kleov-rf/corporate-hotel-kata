namespace CorporateHotel.HotelManagement.Domain;

public interface IHotelRepository
{
    void AddHotel(Hotel newHotel);
    Hotel FindHotelBy(HotelId hotelId);
}