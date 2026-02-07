using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto06_TelaDeLogin.Models;

namespace Asp.Net_Projeto06_TelaDeLogin.Controllers;

public class HomeController : Controller
{
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
