namespace CorporateHotel.HotelManagement.Domain;

public class Hotel
{
    public readonly HotelId Id;
    public readonly string Name;

    public Hotel(HotelId id, string name)
    {
        Id = id;
        Name = name;
    }

    protected bool Equals(Hotel other)
    {
        return Id.Equals(other.Id) && Name == other.Name;
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
        return HashCode.Combine(Id, Name);
    }

    public bool IsIdentifiedBy(HotelId hotelId)
    {
        return Id.Equals(hotelId);
    }
}