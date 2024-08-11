using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Infrastructure;
using CorporateHotel.Tests.Helpers;
using JetBrains.Annotations;

namespace CorporateHotel.Tests.HotelManagement.Infrastructure;

[TestSubject(typeof(InMemoryHotelRepository))]
public class InMemoryHotelRepositoryShould
{

    [Fact]
    public void AddNewHotel()
    {
        //Arrange
        var newHotelId = HotelIdHelper.GenerateNewId();
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
    public async void FindHotel()
    {
        var currentHotelId = HotelIdHelper.GenerateNewId();
        var hotelId = new HotelId(currentHotelId);
        const string currentHotelName = "Current hotel";
        var currentHotel = new Hotel(hotelId, currentHotelName);
        var inMemoryHotelRepository = new InMemoryHotelRepository(new List<Hotel> {currentHotel});
        
        var foundHotel = await inMemoryHotelRepository.FindHotelBy(hotelId);
        
        Assert.Equal(currentHotel, foundHotel);
    }
    
    private static Hotel GivenAHotelWith(string newHotelId, string newHotelName)
    {
        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        return newHotel;
    }
}
