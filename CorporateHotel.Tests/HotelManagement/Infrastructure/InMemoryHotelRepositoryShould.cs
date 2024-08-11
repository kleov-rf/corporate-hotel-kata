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
        const string newHotelId = "1a30df1f-b92d-4d7f-a875-ea295bd00138";
        const string newHotelName = "New Hotel";
        var newHotel = GivenAHotelWith(newHotelId, newHotelName);
        var hotels = new List<Hotel>();

        var inMemoryHotelRepository = new InMemoryHotelRepository(hotels);
        
        //Act
        inMemoryHotelRepository.AddHotel(newHotel);
        
        //Assert
        Assert.Contains(newHotel, hotels);
    }

    [Fact]
    public void FindHotel()
    {
        var currentHotelId = "39379273-be6a-4d3f-90c9-7c77de3c5de1";
        var hotelId = new HotelId(currentHotelId);
        var currentHotelName = "Current hotel";
        var currentHotel = new Hotel(hotelId, currentHotelName);
        var inMemoryHotelRepository = new InMemoryHotelRepository(new List<Hotel> {currentHotel});
        
        var foundHotel = inMemoryHotelRepository.FindHotelBy(hotelId);
        
        Assert.Equal(currentHotel, foundHotel);
    }
    
    private static Hotel GivenAHotelWith(string newHotelId, string newHotelName)
    {
        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        return newHotel;
    }
}
