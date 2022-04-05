using Microsoft.AspNetCore.Mvc;
using NewWebApi_1.WebApi.Services;

namespace NewWebApi_1.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodController : ControllerBase
{
    public IFoodService _foodService;
    
    private readonly ILogger<FoodController> _logger;

    public FoodController(ILogger<FoodController> logger, IFoodService foodService)
    {
        _logger = logger;
        _foodService = foodService;
    }

    [HttpGet]
    public ActionResult Get([FromQuery]string? format = null)
    {
        try
        {
            _logger.LogInformation(format);

            return Ok(_foodService.GetAllFoods(format));
        }
        catch(Exception)
        {
            throw;
        }
    }
}
