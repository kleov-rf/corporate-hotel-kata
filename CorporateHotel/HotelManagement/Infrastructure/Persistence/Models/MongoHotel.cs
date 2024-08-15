using CorporateHotel.HotelManagement.Domain;

namespace CorporateHotel.HotelManagement.Infrastructure.Persistence.Models;

public class MongoHotel 
{

    public string Id { get; set; }
    public string Name { get; set; }
    
    private MongoHotel(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public static MongoHotel FromDomain(Hotel hotel)
    {
        return new MongoHotel(hotel.Id.ToString(), hotel.Name);
    }
    
    protected bool Equals(MongoHotel other)
    {
        return Id == other.Id && Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MongoHotel)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }

    public Hotel? ToDomain()
    {
        return new Hotel(new HotelId(Id), Name);
    }
}