using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CorporateHotel.HotelManagement.Infrastructure;

public class HotelController
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public ActionResult AddHotel(string hotelId, string hotelName)
    {
        _hotelService.AddHotel(new HotelId(hotelId), hotelName);
        return null!;
    }

    public Hotel FindHotelById(string hotelId)
    {
        throw new NotImplementedException();
    }
}