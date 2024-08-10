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

    [Fact]
    public void ReturnFoundHotelFromRepository()
    {
        var hotelRepository = new Mock<IHotelRepository>();
        var hotelService = new HotelService(hotelRepository.Object);
        var foundHotelName = "Found Hotel";
        var foundHotelId = "600cfb4f-6337-41fa-8118-3069ce010305";
        var hotelId = new HotelId(foundHotelId);
        var foundHotel = new Hotel(hotelId, foundHotelName);
        hotelRepository.Setup(repository => repository.FindHotelBy(hotelId)).Returns(foundHotel);

        var returnHotel = hotelService.FindHotelBy(hotelId);
        
        Assert.Equal(foundHotel, returnHotel);
    }
}