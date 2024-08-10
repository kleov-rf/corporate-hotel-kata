using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CorporateHotel.Tests.HotelManagement.Infrastructure;

[TestSubject(typeof(HotelController))]
public class HotelControllerShould
{

    [Fact]
    public void CallHotelServiceWhenAddingNewHotel()
    {
        var hotelService = new Mock<IHotelService>();
        var hotelController = new HotelController(hotelService.Object);

        const string newHotelId = "61541251-bddd-4dfb-b3f5-70ad02707846";
        var hotelId = new HotelId(newHotelId);
        var newHotelName = "New Hotel";
        
        hotelController.AddHotel(newHotelId, newHotelName);

        hotelService.Verify(service => service.AddHotel(hotelId, newHotelName), Times.Once);
    }

    [Fact]
    public void ReturnOKWhenAddingNewHotelSuccessful()
    {
        var hotelService = new Mock<IHotelService>();
        hotelService.Setup(service => service.AddHotel(It.IsAny<HotelId>(), It.IsAny<string>())).Verifiable();
        var hotelController = new HotelController(hotelService.Object);
        var newHotelId = "3220567b-5f11-4f8f-b7ae-c7d730ae0b4e";
        var newHotelName = "New Hotel";

        var actionResult = hotelController.AddHotel(newHotelId, newHotelName);
        
        Assert.IsType<ActionResult<Hotel>>(actionResult);
    }
}