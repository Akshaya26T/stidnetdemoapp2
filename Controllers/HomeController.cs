using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using stidnetdemoapp2.Models;

namespace stidnetdemoapp2.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _config;

    public HomeController(ILogger<HomeController> logger, IConfiguration config)
    {
    _logger = logger;
    _config = config;
    }

    public IActionResult Index()
    {
        var settings = new AppSettings
        {
            SiteName = _config["AppSettings:SiteName"],
            MaxItems = _config.GetValue<int>("AppSettings:MaxItems")
        };
    
        return View(settings);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

