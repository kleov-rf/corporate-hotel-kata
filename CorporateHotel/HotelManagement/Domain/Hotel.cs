namespace CorporateHotel.HotelManagement.Domain;

public class Hotel
{
    public readonly HotelId HotelId;
    private readonly string _hotelName;

    public Hotel(HotelId hotelId, string hotelName)
    {
        HotelId = hotelId;
        _hotelName = hotelName;
    }

    protected bool Equals(Hotel other)
    {
        return HotelId.Equals(other.HotelId) && _hotelName == other._hotelName;
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
        return HashCode.Combine(HotelId, _hotelName);
    }

    public bool IsIdentifiedBy(HotelId hotelId)
    {
        return HotelId.Equals(hotelId);
    }
}