using HelloMVC.Data;
using HelloMVC.Entities;
using HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloMVC.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HelloMVCContext context;

    public HomeController(ILogger<HomeController> logger, HelloMVCContext context)
    {
        _logger = logger;
        this.context = context;
    }

    public IActionResult Index()
    {
        return View();
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
