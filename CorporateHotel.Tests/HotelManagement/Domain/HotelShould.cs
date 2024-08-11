using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.Tests.Helpers;
using JetBrains.Annotations;

namespace CorporateHotel.Tests.HotelManagement.Domain;

[TestSubject(typeof(Hotel))]
public class HotelShould
{
    [Fact]
    public void IdentifyItselfByItsId()
    {
        var newHotelId = HotelIdHelper.GenerateNewId();
        var hotelId = new HotelId(newHotelId);
        const string hotelName = "New Hotel";
        var hotel = new Hotel(hotelId, hotelName);

        var isIdentifiedBy = hotel.IsIdentifiedBy(hotelId);
        
        Assert.True(isIdentifiedBy);
    }
}