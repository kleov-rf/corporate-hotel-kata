using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CorporateHotel.Tests.Acceptance;

public class HotelServiceShould
{
    [Fact]
    public void AddNoExistingHotel()
    {
        // Arrange
        const string newHotelId = "0a3d02e8-fba3-4dbb-ba36-3e46cea570f7";
        string newHotelName = "Name";
        var inMemoryHotelRepository = new InMemoryHotelRepository();
        var hotelService = new HotelService(inMemoryHotelRepository);
        var hotelController = new HotelController(hotelService);
        
        // Act
        var addHotel = hotelController.AddHotel(newHotelId, newHotelName);
        
        // Assert
        Assert.IsType<OkObjectResult>(addHotel);

        var foundHotelById = hotelController.FindHotelById(newHotelId);

        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        Assert.Equal(newHotel, foundHotelById);
    }
}