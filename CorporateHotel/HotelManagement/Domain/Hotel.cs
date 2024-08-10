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

    protected bool Equals(Hotel other)
    {
        return _hotelId.Equals(other._hotelId) && _hotelName == other._hotelName;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Hotel)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_hotelId, _hotelName);
    }
}