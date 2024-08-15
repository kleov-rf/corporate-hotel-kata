namespace CorporateHotel.HotelManagement.Domain;

public class HotelId
{
    private readonly Guid _id;

    public HotelId(string id)
    {
        _id = new Guid(id);
    }
    
    protected bool Equals(HotelId other)
    {
        return _id == other._id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((HotelId)obj);
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }

    public override string ToString()
    {
        return _id.ToString();
    }
}