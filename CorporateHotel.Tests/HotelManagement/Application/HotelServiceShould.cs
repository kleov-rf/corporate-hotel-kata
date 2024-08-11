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
    public void CallHotelRepositoryWhenAddingNewHotel()
    {
        const string newHotelName = "New Hotel";
        const string newHotelId = "3598ca62-4516-4a75-9eb3-64a6f1c59381";
        var hotelId = new HotelId(newHotelId);
        var newHotel = new Hotel(hotelId, newHotelName);
        
        _hotelService.AddHotel(hotelId, newHotelName);
        
        _hotelRepository.Verify(repository => repository.AddHotel(newHotel), Times.Once);
    }

    [Fact]
    public void CallHotelRepositoryWhenFindingHotelById()
    {
        const string newHotelId = "3598ca62-4516-4a75-9eb3-64a6f1c59381";
        var hotelId = new HotelId(newHotelId);

        _hotelService.FindHotelBy(hotelId);
        
        _hotelRepository.Verify(repository => repository.FindHotelBy(hotelId), Times.Once);
    }

    [Fact]
    public void ReturnFoundHotelFromRepository()
    {
        const string foundHotelName = "Found Hotel";
        const string foundHotelId = "600cfb4f-6337-41fa-8118-3069ce010305";
        var hotelId = new HotelId(foundHotelId);
        var foundHotel = new Hotel(hotelId, foundHotelName);
        _hotelRepository.Setup(repository => repository.FindHotelBy(hotelId)).Returns(foundHotel);

        var returnHotel = _hotelService.FindHotelBy(hotelId);
        
        Assert.Equal(foundHotel, returnHotel);
    }

    [Fact]
    public void ThrowExceptionWhenAddingExistingHotel()
    {
        var existingHotelId = HotelIdHelper.GenerateNewId();
        var existingHotelName = "existing hotel";
        
        _hotelRepository.Verify(repository => repository.FindHotelBy(new HotelId(existingHotelId)), Times.Once);

        Assert.Throws<AlreadyExistingHotelException>(
            () => _hotelService.AddHotel(new HotelId(existingHotelId), existingHotelName)
        );
    }
}