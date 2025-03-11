using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioDT191G.Data;
using PortfolioDT191G.Models;

namespace PortfolioDT191G.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    //Added context
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        //Hämta data från databasen
        var courses = _context.Courses.ToList(); //Hämta Courses
        var skills = _context.Skills.ToList(); // Hämta Skills
        var frameworks = _context.Frameworks.ToList(); // Hämta Ramverk

        //Skapa ViewModel
        var viewModel = new HomeModel
        {
            Courses = courses,
            Skills = skills,
            Frameworks = frameworks
        };
        return View(viewModel);
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
