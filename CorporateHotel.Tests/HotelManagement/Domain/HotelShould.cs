using CorporateHotel.HotelManagement.Domain;
using JetBrains.Annotations;

namespace CorporateHotel.Tests.HotelManagement.Domain;

[TestSubject(typeof(Hotel))]
public class HotelShould
{

    [Fact]
    public void IdentifyItselfByItsId()
    {
        var newHotelId = "88012242-b3f8-4a7c-8aed-52eb19209611";
        HotelId hotelId = new HotelId(newHotelId);
        var hotelName = "New Hotel";
        Hotel hotel = new Hotel(hotelId, hotelName);

        var isIdentifiedBy = hotel.IsIdentifiedBy(hotelId);
        
        Assert.True(isIdentifiedBy);
    }
}