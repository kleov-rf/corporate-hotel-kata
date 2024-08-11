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
        const string newHotelName = "Name";
        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        
        var inMemoryHotelRepository = new InMemoryHotelRepository();
        var hotelService = new HotelService(inMemoryHotelRepository);
        var hotelController = new HotelController(hotelService);
        
        // Act
        var addHotel = hotelController.AddHotel(newHotelId, newHotelName);
        var foundHotelById = hotelController.FindHotelById(newHotelId);
        
        // Assert
        Assert.IsType<OkObjectResult>(addHotel.Result);
        Assert.Equal(newHotel, foundHotelById);
    }
}