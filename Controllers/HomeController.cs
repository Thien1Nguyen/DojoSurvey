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

    static Survey? student;
    [HttpPost("create")]
    public IActionResult Create(Survey newStudent)
    {
        if(!ModelState.IsValid){
            return View("Index");
        }
        student = newStudent;
        return RedirectToAction("Result");
    }

    [HttpGet("result")]
    public IActionResult Result()
    {
        return View(student);
    }

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
