﻿using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure;
using CorporateHotel.HotelManagement.Infrastructure.Persistence;
using CorporateHotel.Tests.Acceptance.Config;
using CorporateHotel.Tests.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CorporateHotel.Tests.Acceptance;

public class HotelServiceShould : MongoDbTestBase
{
    public HotelServiceShould(MongoDbFixture fixture) : base(fixture)
    {
        
    }
    
    [Fact]
    public async Task AddNoExistingHotel()
    {
        // Arrange
        var newHotelId = HotelIdHelper.GenerateNewId();
        const string newHotelName = "Name";
        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        
        var mongoDbHotelRepository = new MongoDbHotelRepository(_database);
        var hotelService = new HotelService(mongoDbHotelRepository);
        var hotelController = new HotelController(hotelService);
        
        // Act
        var addHotel = await hotelController.AddHotel(newHotelId, newHotelName);
        var foundHotelById = await hotelController.FindHotelById(newHotelId);
        
        // Assert
        Assert.IsType<OkObjectResult>(addHotel.Result);
        Assert.Equal(newHotel, foundHotelById);
    }

    [Fact]
    public async Task NotAddExistingHotelTwice()
    {
        //Arrange
        var newHotelId = HotelIdHelper.GenerateNewId();
        const string newHotelName = "Hotel Name";
        var hotelId = new HotelId(newHotelId);
        var currentHotel = new Hotel(hotelId, newHotelName);
        var currentHotels = new List<Hotel> { currentHotel };

        var inMemoryHotelRepository = new InMemoryHotelRepository(currentHotels);
        var hotelService = new HotelService(inMemoryHotelRepository);
        var hotelController = new HotelController(hotelService);
        
        //Act
        var addHotel = await hotelController.AddHotel(newHotelId, newHotelName);
        
        //Assert
        Assert.IsType<ConflictResult>(addHotel.Result);
        Assert.Single(currentHotels);
    }
}