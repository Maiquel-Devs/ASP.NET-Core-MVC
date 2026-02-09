using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Projeto06_TelaDeLogin.Models;

namespace Asp.Net_Projeto06_TelaDeLogin.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()    // Usado para links apos logar (se eu criar um outro arquivo e quiser criar um link para voltar nele eu uso essa função Index no HomeController.cs)
    {
        // Verifica se existe o "carimbo" de login na sessão
        if (HttpContext.Session.GetString("UsuarioLogado") == null)
        {
            // Se não estiver logado, redireciona para a página de login
            return RedirectToAction("Login", "Account");
        }

        // Esta página só será vista depois que o usuário logar
        return View();
    }

    public IActionResult Login()
    {
        return RedirectToAction("Login", "Account"); // Vai para o arquivo AccountController.cs
    }

    public IActionResult CriarConta()
    {
        return RedirectToAction("CriarConta", "Account"); // Vai para o arquivo AccountController.cs
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
