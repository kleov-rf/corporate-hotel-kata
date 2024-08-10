using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure;
using JetBrains.Annotations;

namespace CorporateHotel.Tests.HotelManagement.Infrastructure;

[TestSubject(typeof(InMemoryHotelRepository))]
public class InMemoryHotelRepositoryShould
{

    [Fact]
    public void AddNewHotel()
    {
        //Arrange
        var newHotelId = "1a30df1f-b92d-4d7f-a875-ea295bd00138";
        var newHotelName = "New Hotel";
        var hotelId = new HotelId(newHotelId);
        Hotel newHotel = new Hotel(hotelId, newHotelName);
        var hotels = new List<Hotel>();

        var inMemoryHotelRepository = new InMemoryHotelRepository(hotels);
        
        //Act
        inMemoryHotelRepository.AddHotel(newHotel);
        
        //Assert
        Assert.Contains(newHotel, hotels);
    }
}