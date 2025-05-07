using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Rentio.Models;

namespace Rentio.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class CarController : Controller {

    [HttpGet]
    public JsonResult Get() {
        var car = new Car();
        return Json(car);
    }
    
    [HttpGet("{id}")]
    public JsonResult Get(int id) {
        return Json("");
    }

    [HttpPost]
    public JsonResult Post(string value) {
        return Json("");
    }
    
    [HttpPut("{id}")]
    public JsonResult Put(int id, string value) {
        return Json("");
    }
    
    [HttpDelete("{id}")]
    public JsonResult Delete(int id) {
        return Json("");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}