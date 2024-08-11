using CorporateHotel.HotelManagement.Domain;
using JetBrains.Annotations;

namespace CorporateHotel.Tests.HotelManagement.Domain;

[TestSubject(typeof(Hotel))]
public class HotelShould
{
    [Fact]
    public void IdentifyItselfByItsId()
    {
        const string newHotelId = "88012242-b3f8-4a7c-8aed-52eb19209611";
        var hotelId = new HotelId(newHotelId);
        const string hotelName = "New Hotel";
        var hotel = new Hotel(hotelId, hotelName);

        var isIdentifiedBy = hotel.IsIdentifiedBy(hotelId);
        
        Assert.True(isIdentifiedBy);
    }
}