using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Domain.Exception;
using CorporateHotel.Tests.Helpers;
using JetBrains.Annotations;
using Moq;

namespace CorporateHotel.Tests.HotelManagement.Application;

[TestSubject(typeof(HotelService))]
public class HotelServiceShould
{
    private readonly Mock<IHotelRepository> _hotelRepository;
    private readonly HotelService _hotelService;

    public HotelServiceShould()
    {
        _hotelRepository = new Mock<IHotelRepository>();
        _hotelService = new HotelService(_hotelRepository.Object);
    }

    [Fact]
    public async Task CallHotelRepositoryWhenAddingNewHotel()
    {
        const string newHotelName = "New Hotel";
        var newHotelId = HotelIdHelper.GenerateNewId();
        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        
        await _hotelService.AddHotel(hotelId, newHotelName);
        
        _hotelRepository.Verify(repository => repository.AddHotel(newHotel), Times.Once);
    }

    [Fact]
    public void CallHotelRepositoryWhenFindingHotelById()
    {
        var newHotelId = HotelIdHelper.GenerateNewId();
        var hotelId = new HotelId(newHotelId);

        _hotelService.FindHotelBy(hotelId);
        
        _hotelRepository.Verify(repository => repository.FindHotelBy(hotelId), Times.Once);
    }

    [Fact]
    public async void ReturnFoundHotelFromRepository()
    {
        const string foundHotelName = "Found Hotel";
        var foundHotelId = HotelIdHelper.GenerateNewId();
        var hotelId = new HotelId(foundHotelId);
        var foundHotel = new Hotel(hotelId, foundHotelName);
        _hotelRepository.Setup(repository => repository.FindHotelBy(hotelId)).ReturnsAsync(foundHotel);

        var returnHotel = await _hotelService.FindHotelBy(hotelId);
        
        Assert.Equal(foundHotel, returnHotel);
    }

    [Fact]
    public void ThrowExceptionWhenAddingExistingHotel()
    {
        var existingHotelId = HotelIdHelper.GenerateNewId();
        const string existingHotelName = "existing hotel";
        var hotelId = new HotelId(existingHotelId);
        
        _hotelRepository.Setup(repository => repository.FindHotelBy(hotelId))
            .ReturnsAsync(new Hotel(hotelId, existingHotelName));
        
        Assert.ThrowsAsync<AlreadyExistingHotelException>(
            () => _hotelService.AddHotel(hotelId, existingHotelName)
        );
        
        _hotelRepository.Verify(repository => repository.FindHotelBy(hotelId), Times.Once);
    }
}