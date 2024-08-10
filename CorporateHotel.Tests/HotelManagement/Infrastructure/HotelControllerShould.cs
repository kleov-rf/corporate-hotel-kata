﻿using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure;
using JetBrains.Annotations;
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
}