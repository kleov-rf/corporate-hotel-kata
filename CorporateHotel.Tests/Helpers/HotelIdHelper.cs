namespace CorporateHotel.Tests.Helpers;

public class HotelIdHelper
{
    public static string GenerateNewId()
    {
        return Guid.NewGuid().ToString();
    }
}