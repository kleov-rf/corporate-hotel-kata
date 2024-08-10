using Microsoft.AspNetCore.Mvc;

namespace CorporateHotel.Tests.Acceptance;

public class HotelServiceShould
{
    [Fact]
    public void AddNoExistingHotel()
    {
        // Arrange
        string hotelName = "Name";
        var hotelController = new HotelController();
        
        // Act
        var addHotel = hotelController.AddHotel(hotelName);
        
        // Assert
        Assert.IsType<OkObjectResult>(addHotel);

        var foundHotelById = hotelController.FindHotelById(hotelID);
        Assert.Equal(newHotel, foundHotelById);
    }
}