using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Domain.Exception;
using CorporateHotel.HotelManagement.Infrastructure;
using CorporateHotel.Tests.Helpers;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CorporateHotel.Tests.HotelManagement.Infrastructure;

[TestSubject(typeof(HotelController))]
public class HotelControllerShould
{
    private readonly Mock<IHotelService> _hotelService;
    private readonly HotelController _hotelController;

    public HotelControllerShould()
    {
        _hotelService = new Mock<IHotelService>();
        _hotelController = new HotelController(_hotelService.Object);
    }

    [Fact]
    public void CallHotelServiceWhenAddingNewHotel()
    {
        var newHotelId = HotelIdHelper.GenerateNewId();
        const string newHotelName = "New Hotel";
        var hotelId = new HotelId(newHotelId);
        
        _hotelController.AddHotel(newHotelId, newHotelName);

        _hotelService.Verify(service => service.AddHotel(hotelId, newHotelName), Times.Once);
    }

    [Fact]
    public void ReturnOkWhenAddingNewHotelSuccessful()
    {
        var newHotelId = HotelIdHelper.GenerateNewId();
        const string newHotelName = "New Hotel";
        _hotelService.Setup(service => service.AddHotel(It.IsAny<HotelId>(), It.IsAny<string>())).Verifiable();

        var actionResult = _hotelController.AddHotel(newHotelId, newHotelName);
        
        Assert.IsType<ActionResult<Hotel>>(actionResult);
    }
    
    [Fact]
    public void ReturnInternalServerErrorStatusWhenServiceThrowsException()
    {
        //Arrange
        const string newHotelName = "New Hotel";
        var newHotelId = HotelIdHelper.GenerateNewId();
        _hotelService.Setup(service => 
            service.AddHotel(It.IsAny<HotelId>(), It.IsAny<string>())).Throws<Exception>();
        
        //Act
        var actionResult = _hotelController.AddHotel(newHotelId, newHotelName);
        
        //Assert
        Assert.IsType<ActionResult<Hotel>>(actionResult);
        var statusCodeResult = Assert.IsType<ObjectResult>(actionResult.Result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }

    [Fact]
    public void CallHotelServiceWhenFindingHotel()
    {
        var newHotelId = HotelIdHelper.GenerateNewId();
        var hotelId = new HotelId(newHotelId);

        _hotelController.FindHotelById(newHotelId);
        
        _hotelService.Verify(service => service.FindHotelBy(hotelId), Times.Once);
    }

    [Fact]
    public void ReturnConflictStatusWhenAddingExistingHotel()
    {
        var existingHotelId = HotelIdHelper.GenerateNewId();
        const string existingHotelName = "existing hotel";
        _hotelService.Setup(service => service.AddHotel(new HotelId(existingHotelId), existingHotelName)).Throws<AlreadyExistingHotelException>();

        var actionResult = _hotelController.AddHotel(existingHotelId, existingHotelName);
        
        Assert.IsType<ActionResult<Hotel>>(actionResult);
        var statusCodeResult = Assert.IsType<ConflictResult>(actionResult.Result);
        Assert.Equal(StatusCodes.Status409Conflict, statusCodeResult.StatusCode);
    }
}