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

    public ActionResult<Hotel> AddHotel(string hotelId, string hotelName)
    {
        try
        {
            _hotelService.AddHotel(new HotelId(hotelId), hotelName);
            return new OkObjectResult(null);
        }
        catch (Exception e)
        {
            return new ObjectResult(e)
            {
                StatusCode = 500
            };
        }
    }

    public Hotel FindHotelById(string hotelId)
    {
        throw new NotImplementedException();
    }
}