using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using JetBrains.Annotations;
using Moq;

namespace CorporateHotel.Tests.HotelManagement.Application;

[TestSubject(typeof(HotelService))]
public class HotelServiceShould
{

    [Fact]
    public void CallHotelRepositoryWhenAddingNewHotel()
    {
        var hotelRepository = new Mock<IHotelRepository>();
        var hotelService = new HotelService(hotelRepository.Object);

        var newHotelName = "New Hotel";
        var newHotelId = "3598ca62-4516-4a75-9eb3-64a6f1c59381";
        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        
        hotelService.AddHotel(hotelId, newHotelName);
        hotelRepository.Verify(repository => repository.AddHotel(newHotel), Times.Once);
    }

    [Fact]
    public void CallHotelRepositoryWhenFindingHotelById()
    {
        var hotelRepository = new Mock<IHotelRepository>();
        var hotelService = new HotelService(hotelRepository.Object);
        var newHotelId = "3598ca62-4516-4a75-9eb3-64a6f1c59381";
        var hotelId = new HotelId(newHotelId);

        hotelService.FindHotelBy(hotelId);
        
        hotelRepository.Verify(repository => repository.FindHotelBy(hotelId), Times.Once);
    }
}