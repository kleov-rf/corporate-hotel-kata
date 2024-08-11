using CorporateHotel.HotelManagement.Application;
using CorporateHotel.HotelManagement.Domain;
using CorporateHotel.HotelManagement.Domain.Exception;
using Microsoft.AspNetCore.Mvc;

namespace CorporateHotel.HotelManagement.Infrastructure;

public class HotelController
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    public async Task<ActionResult<Hotel>> AddHotel(string hotelId, string hotelName)
    {
        try
        {
            await _hotelService.AddHotel(new HotelId(hotelId), hotelName);
            return new OkObjectResult(null);
        }
        catch (AlreadyExistingHotelException e)
        {
            return new ConflictResult();
        }
        catch (Exception e)
        {
            return new ObjectResult(e)
            {
                StatusCode = 500
            };
        }
    }

    public async Task<Hotel?> FindHotelById(string hotelId)
    {
        return await _hotelService.FindHotelBy(new HotelId(hotelId));
    }
}