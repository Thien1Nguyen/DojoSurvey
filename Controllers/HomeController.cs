using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

namespace DojoSurvey.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/result")]
    public IActionResult Create(Survey newStudent)
    {
        return View("Result", newStudent);
    }
    // [HttpPost("/result")]
    // public IActionResult Result(string name, string location, string language, string comment = "nothing here")
    // {
    //     ViewBag.Name = name;
    //     ViewBag.Location = location;
    //     ViewBag.Language = language;
    //     ViewBag.Comment = comment;
    //     return View();
    // }

    // [HttpPost("/result")]
    // public IActionResult Result()
    // {
    //     return View();
    // }

    [HttpGet("{**path}")]
    public RedirectResult Unknown()
    {
        return Redirect("/");
    }

    [HttpGet("privacy")]
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
