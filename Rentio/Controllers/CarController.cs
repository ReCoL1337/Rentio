using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rentio.Models;
using Rentio.Services;

namespace Rentio.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class CarController : Controller {
    private CarService _carService;
    public CarController(CarService carService) {
        _carService = carService;
    }

    [HttpGet("")]
    public async Task<ActionResult> Get() {
        var result = await _carService.GetAllAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id) {
        var result = await _carService.GetAsync(id);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<ActionResult> Post([FromBody]Car car ) {
        var result = await _carService.Add(car);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody]Car car) {
        var result = await _carService.Update(car);
        return Ok(result);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id) {
        var car = await _carService.GetAsync(id);
        car.Deleted = true;
        var result = await _carService.Update(car);
        
        return Ok(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet("error")]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}