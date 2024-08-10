namespace CorporateHotel.HotelManagement.Domain;

public class Hotel
{
    private readonly HotelId _hotelId;
    private readonly string _hotelName;

    public Hotel(HotelId hotelId, string hotelName)
    {
        _hotelId = hotelId;
        _hotelName = hotelName;
    }
}