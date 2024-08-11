namespace CorporateHotel.HotelManagement.Domain;

public interface IHotelRepository
{
    Task AddHotel(Hotel newHotel);
    Task<Hotel?> FindHotelBy(HotelId hotelId);
}